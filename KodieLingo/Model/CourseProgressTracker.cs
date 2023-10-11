namespace KodieLingo.Model
{
	public class CourseProgressTracker
	{
		public int Id { get; set; }
		public User User { get; set; }

		public Course Course { get; set; }
		public int Progress { get; set; }
	}
}
