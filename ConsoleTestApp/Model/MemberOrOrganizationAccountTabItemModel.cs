namespace ConsoleTestApp.Model
{
    public class MemberOrOrganizationAccountTabItemModel
    {
        public string ACCOUNT_NUMBER { get; set; }

        public string PARTY_ID { get; set; }

        public string ACCOUNT_TYPE { get; set; }

        public string ACCOUNT_NAME { get; set; }

        public string FIRST_NAME { get; set; }

        public string MIDDLE_NAME { get; set; }

        public string LAST_NAME { get; set; }

        public string WEB_STORE { get; set; }

        public string MARKETTING_PREFERENCE { get; set; }

        public string AREA_OF_INTEREST1 { get; set; }

        public string AREA_OF_INTEREST2 { get; set; }

        public string AREA_OF_INTEREST3 { get; set; }

        public string DUNS_NUMBER { get; set; }

        public MemberOrOrganizationRelationshipDataModel RELATIONSHIP { get; set; }

        public MemberOrOrganizationCommunicationDataModel COMMUNICATION { get; set; }

        public MemberOrOrganizationAddressDataModel ADDRESS { get; set; }
    }
}
