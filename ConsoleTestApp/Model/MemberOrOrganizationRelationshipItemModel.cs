using System;

namespace ConsoleTestApp.Model
{
    public class MemberOrOrganizationRelationshipItemModel
    {
        public string CONTACT_ACCOUNT_NUMBER { get; set; }

        public string RELATIONSHIP_TYPE { get; set; }

        public string CONTACT_ID { get; set; }

        public string RELATIONSHIP_STATUS { get; set; }

        public string START_DATE { get; set; }

        public string END_DATE { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
