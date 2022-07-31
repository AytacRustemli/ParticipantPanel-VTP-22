using Entities;

namespace ParticipantPanel.ViewModels
{
    public class HomeVM
    {
        public List<ItWeb> Itweb { get; set; }
        public List<Af> Afs { get; set; }
        public List<ItRm> ItRms { get; set; }
        public List<HR> HRs { get; set; }
        public List<Logistic> logistics { get; set; }
        public List<int> ages { get; set; }
        public List<int> ageCounts { get; set; }
        public int itWebCount { get; set; }
        public int afCount { get; set; }
        public int ceCount { get; set; }
        public int hrCount { get; set; }
        public int lgCount { get; set; }
    }
}
