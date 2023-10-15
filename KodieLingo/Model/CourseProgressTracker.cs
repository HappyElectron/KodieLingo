namespace KodieLingo.Model
{
	public class CourseProgressTracker
	{
		public int Id { get; set; }
		public User User { get; set; }

		public Section Section { get; set; }
		public int Progress { get; set; }
	}
}
