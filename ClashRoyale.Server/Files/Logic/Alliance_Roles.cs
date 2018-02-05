using ClashRoyale.Server.Files.Helpers;
using ClashRoyale.Server.Files.Reader;

namespace ClashRoyale.Server.Files.Logic
{
    internal class Alliance_Roles : Data
    {
        public Alliance_Roles(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Load(this, GetType(), Row);
        }

        public string Name { get; set; }

        public int Level { get; set; }

        public string TID { get; set; }

        public bool CanInvite { get; set; }

        public bool CanSendMail { get; set; }

        public bool CanChangeAllianceSettings { get; set; }

        public bool CanAcceptJoinRequest { get; set; }

        public bool CanKick { get; set; }

        public bool CanBePromotedToLeader { get; set; }

        public bool CanPromoteToOwnLevel { get; set; }
    }
}