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
        private const string ApiKey = "7b1d619ad246e121ab2c91195bc1521a-us3"; // for user moltestuser2
        private const string ListId = "169573aab7"; // Test list #1

        [TestMethod]
        public void AddRemoveMergeVar()
        {
            //  Arrange
            MailChimpManager mc = new MailChimpManager(ApiKey);

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
            MailChimpManager mc = new MailChimpManager(ApiKey);

            //  Create
            int groupingId = mc.AddListInterestGrouping(ListId, new string[]{"default1" });

            //  Update
            bool result = mc.UpdateListInterestGrouping(groupingId, "name", "newName");
            Assert.IsTrue(result);

            //  Delete
            result = mc.DeleteListInterestGrouping(groupingId);
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void AddRemoveInterestGroup_Successful()
        {
            //  Arrange
            MailChimpManager mc = new MailChimpManager(ApiKey);

            //  Add grouping
            int groupingId = mc.AddListInterestGrouping(ListId, new string[] { "default2" });

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
            throw new NotImplementedException();
        }

        [TestMethod]
        public void UpdateMember_Successful()
        {
            //  Arrange
            MailChimpManager mc = new MailChimpManager(ApiKey);

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
