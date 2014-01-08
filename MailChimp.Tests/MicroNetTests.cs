using System;
using System.Collections.Generic;
using MailChimp.Lists;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using MailChimp.Helper;
using System.Diagnostics;

namespace MailChimp.Tests
{
    [TestClass]
    public class MicroNetTests
    {
        //private const string ApiKey = "7b1d619ad246e121ab2c91195bc1521a-us3"; // for user moltestuser2
        //private const string ListId = "169573aab7"; // Test list #1

        [TestMethod]
        public void AddRemoveMergeVar()
        {
            //  Arrange
            MailChimpManager mc = new MailChimpManager(TestGlobal.Test_APIKey);
            var list = mc.GetLists();
            string ListId = list.Data.Where(x => x.Name == "ChamberMaster").FirstOrDefault().Id;
            //  Act
            AddListMergeVarResult result = mc.AddMergeVar(ListId, "MYVAR", "My VAR", null);

            Assert.AreEqual("MYVAR", result.Tag);

            bool deleted = mc.DeleteMergeVar(ListId, "MYVAR");
            Assert.IsTrue(deleted);
        }

        [TestMethod]
        public void AddRemoveInterestGrouping_Successful()
        {
            //  Arrange
            MailChimpManager mc = new MailChimpManager(TestGlobal.Test_APIKey);
            var list = mc.GetLists();
            string ListId = list.Data.Where(x => x.Name == "ChamberMaster").FirstOrDefault().Id;

            //  Create
            int groupingId = mc.AddListInterestGrouping(ListId, "test group", new string[]{"default1" });

            //  Update
            bool result = mc.UpdateListInterestGrouping(groupingId, "name", "Auto-Created - Don't Delete");
            Assert.IsTrue(result);

            mc.AddListInterestGroup(ListId, "Group 1", groupingId);

            //  Delete
            //result = mc.DeleteListInterestGrouping(groupingId);
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void AddRemoveInterestGroup_Successful()
        {
            //  Arrange
            MailChimpManager mc = new MailChimpManager(TestGlobal.Test_APIKey);
            var list = mc.GetLists();
            string ListId = list.Data.Where(x => x.Name == "ChamberMaster").FirstOrDefault().Id;

            //  Add grouping
            int groupingId = mc.AddListInterestGrouping(ListId, "Test Group", new string[] { "default2" });

            //  Add groups
            bool result = mc.AddListInterestGroup(ListId, "SomeGroup1", groupingId);
            Assert.IsTrue(result);
            result = mc.AddListInterestGroup(ListId, "SomeGroup2", null);
            Assert.IsTrue(result);

            //  Remove groups
            result = mc.DeleteListInterestGroup(ListId, "SomeGroup1", groupingId);
            Assert.IsTrue(result);
            result = mc.DeleteListInterestGroup(ListId, "SomeGroup2", null);
            Assert.IsTrue(result);

            //  Delete grouping
            mc.DeleteListInterestGrouping(groupingId);
        }

        [TestMethod]
        public void ExportList_Successful()
        {
            //  Arrange
            MailChimpManager mc = new MailChimpManager(TestGlobal.Test_APIKey);
            var list = mc.GetLists();
            string ListId = list.Data.Where(x => x.Name == "ChamberMaster").FirstOrDefault().Id;

            // add test member

            string testEmail = "test" + (new Random()).Next(99999) + "@micronet.com";
            EmailParameter subscription = mc.Subscribe(ListId, new EmailParameter() {Email = testEmail}, sendWelcome: false, doubleOptIn: false);

            try
            {
                // export list and check the new member is present

                var result = mc.ExportList(ListId, null, null, null, null);

                // should return at least header row
                Assert.IsTrue(result.Any());

                // in the header row find index of the field that contains Email address
                int idx = Array.IndexOf(result[0], result[0].First(s => s.ToLower().Contains("email")));

                // ensure the new member were exported
                Assert.IsTrue(result.Skip(1).Any(r => r[idx] == testEmail));
            }
            finally
            {
                // remove test member
                UnsubscribeResult rslt = mc.Unsubscribe(ListId, emailParam: new EmailParameter() { Email = testEmail },
                                                        deleteMember: true, sendGoodbye: false, sendNotify: false);
            }

        }

        [TestMethod]
        public void UpdateMember_Successful()
        {
            //  Arrange
            MailChimpManager mc = new MailChimpManager(TestGlobal.Test_APIKey);
            var list = mc.GetLists();
            string ListId = list.Data.Where(x => x.Name == "ChamberMaster").FirstOrDefault().Id;

            //  Create merge var "Company Name"
            mc.AddMergeVar(ListId, "COMPNAME", "Company Name", null);

            EmailParameter result = mc.UpdateMember(
                ListId,
                new EmailParameter() {Email = "11190@beeline.ru"},
                new Dictionary<string, string>() {{"COMPNAME", "MicroNet"}},
                null, null);

            // Delete merge var
            bool deleted = mc.DeleteMergeVar(ListId, "COMPNAME");
        }

    }
}
