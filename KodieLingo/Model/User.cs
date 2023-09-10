namespace KodieLingo.Model
{
    /* 
     * 
     */
    public class User
    {
        // Leave everything public to start, tighten security later
        // Ideally, the PW would be contained in an encrypted, separate class with other sensitive/costly information,
        // so that we can pass the easy stuff between pages/friends quickly; this approach is just to get started.
        public int Id { get; set; }
        public int Streak { get; set; } = 0;
        public int LongestStreak { get; set; } = 0;


        // Points are the competitive currency shared between friends.
        // KodieBukz are used to purchase powerups and collectables.
        // Both are awarded from lessons/challenges
        public int WeeklyPoints { get; set; } = 0;
        public int LifetimePoints { get; set; } = 0;
        public int KodieBukz { get; set; } = 0;
        
        
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public bool AllowFriendRequests = true;
        
        // Many users reference many courses
        public ICollection<Course> Course { get; set; } = new List<Course>();

        // Many users reference many friends (except for aiden as he does not have any friends)
        // This structure is awful, i will fix it later.
        public ICollection<User> Friend { get; set;} = new List<User>();
		public ICollection<User> FriendParents { get; set; } = new List<User>();

		// Friend requests: many requests to many users. 
		public ICollection<User> FriendReqIncoming { get; set; } = new List<User>();
		public ICollection<User> FriendReqIncomingParents { get; set; } = new List<User>();

        public ICollection<User> FriendReqOutgoing { get; set; } = new List<User>();
        public ICollection<User> FriendReqOutgoingParents { get; set; } = new List<User>();
    }
}
