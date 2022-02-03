namespace GeoGo.Server.Data
{
    public class Validation
    {
        public class Game
        {
            public const int MaxDescriptionLength = 2000;
            public const int MaxTitleLength = 200;
        }

        public class Feedback
        {
            public const int MaxContentLength = 2000;
            public const int MaxTitleLength = 200;
        }

        public class Location
        {
            public const int MaxNameLength = 100;
        }

        public class Clue
        {
            public const int MaxTextLength = 250;
        }

        public class Riddle
        {
            public const int MaxTextLength = 500;
            public const int MaxAnswerLength = 150;
        }
    }
}
