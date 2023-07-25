namespace AwesomeDevEvents.API.Entities
{
	public class DevEvent
	{
        public DevEvent()
        {
           Speakers = new List<DevEventSpeaker> { };
			isDeleted = false;
        }

        public Guid Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public List<DevEventSpeaker> Speakers { get; set; }

		public bool isDeleted { get; set; }

		public void update(string title, string description, DateTime startDate, DateTime endDate)
		{
			title = Title;
			description = Description;
			startDate = StartDate;
			endDate = EndDate;
		}

		public void delete()
		{
			isDeleted = true;
		}
	}
}
