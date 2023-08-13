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
        public int WeeklyKB { get; set; } = 0;
        public int LifetimeKB { get; set; } = 0;
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }



        public bool AllowFriendRequests = true;



        // Each array stores the id of other DB entries, because storing entire classes/courses/friends is not a good option/
        // The biggest problem I can think of with this approach will center around when we update courses:
        // If the objects are assigned different ids/modified within the DB, we'll need to update users.

        /* EF usesq lists in a weird way - we'd need to define a primary key for each list.
         * I think this entire approach with abstract data types may be a failure. 
         * Commenting this to get the initial commit working, may delete later.
        public List<int>? Friends { get; set; }
        public List<int>? IncomingFriendRequests { get; set; }
        public List<int>? OutgoingFriendRequests { get; set; }
        */


        // Courses list is structured as:
        // id : (question : {right, total})
        // Pretty stupid, can rework later.
        
        // Ok, turns out ef does not permit dictionaries.
        // Time to rethink stuff.
        //public Dictionary<int, KeyValuePair<int, KeyValuePair<int,int>>>? Courses { get; set; }

        // "id : count" structure, will pass the information to an enum that gets updates from the store table
        /*
        public List<int>? PowerUpIds { get; set; }
        public List<int>? PowerUpCounts { get; set; }
        */
    }
}
