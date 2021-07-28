using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadSheddingApp
{
    public class DisplayInfo
    {
        public int day = (int)DateTime.Today.Day;

        private string downTime;
        private TimeSpan beginningTime;
        private TimeSpan endTime;
        private string _downTime;
        private TimeSpan _beginningTime;
        private TimeSpan _endTime;

        public int[,] loadsheddingAreas = new int[12, 16]
            {{1, 13, 1, 13, 2, 14, 2, 14, 3, 15, 3, 15, 4, 16, 4, 16},
             {2, 14, 2, 14, 3, 15, 3, 15, 4, 16, 4, 16, 5, 1, 5, 1 },
             {3, 15, 3, 15, 4, 16, 4, 16, 5, 1, 5, 1, 6, 2, 6, 2 },
             {4, 16, 4, 16, 5, 1, 5, 1, 6, 2, 6, 2, 7, 3, 7, 3 },
             {5, 1, 5, 1, 6, 2, 6, 2, 7, 3, 7, 3, 8, 4, 8, 4 },
             {6, 2, 6, 2, 7, 3, 7, 3, 8, 4, 8, 4, 9, 5, 9, 5 },
             {7, 3, 7, 3, 8, 4, 8, 4, 9, 5, 9, 5, 10, 6, 10, 6 },
             {8, 4, 8, 4, 9, 5, 9, 5, 10, 6, 10, 6, 11, 7, 11, 7 },
             {9, 5, 9, 5, 10, 6, 10, 6, 11, 7, 11, 7, 12, 8, 12, 8 },
             {10, 6, 10, 6, 11, 7, 11, 7, 12, 8, 12, 8, 13, 9, 13, 6 },
             {11, 7, 11, 7, 12, 8, 12, 8, 13, 9, 13, 9, 14, 10, 14, 10 },
             {12, 8, 12, 8, 13, 9, 13, 9, 14, 10, 14, 10, 15, 11, 15, 11 } };

        public int[,] _loadsheddingAreas = new int[12, 16]
            {{9, 5, 9, 5, 10, 6, 10, 6, 11, 7, 11, 7, 12, 8, 12, 8},
             {10, 6, 10, 6, 11, 7, 11, 7, 12, 8, 12, 8, 13, 9, 13, 9},
             {11, 7, 11, 7, 12, 8, 12, 8, 13, 9, 13, 9, 14, 10, 14, 10},
             {12, 8, 12, 8, 13, 9, 13, 9, 14, 10, 14, 10, 15, 11, 15, 11},
             {13, 9, 13, 9, 14, 10, 14, 10, 15, 11, 15, 11, 16, 12, 16, 12},
             {14, 10, 14, 10, 15, 11, 15, 11, 16, 12, 16, 12, 1, 13, 1, 13},
             {15, 11, 15, 11, 16, 12, 16, 12, 1, 13, 1, 13, 2, 14, 2, 14},
             {16, 12, 16, 12, 1, 13, 1, 13, 2, 14, 2, 14, 3, 15, 3, 15},
             {1, 13, 1, 13, 2, 14, 2, 14, 3, 15, 3, 15, 4, 16, 4, 16},
             {2, 14, 2, 14, 3, 15, 3, 15, 4, 16, 4, 16, 5, 1, 5, 1,},
             {3, 15, 3, 15, 4, 16, 4, 16, 5, 1, 5, 1, 6, 2, 6, 2},
             {4, 16, 4, 16, 5, 1, 5, 1, 6, 2, 6, 2, 7, 3, 7, 3} };

        public string[] loadsheddingTime = new string[12]
        { "00:00", "02:00", "04:00", "06:00", "08:00", "10:00", "12:00", "14:00", "16:00", "18:00", "20:00", "22:00"};
        public string[] _loadsheddingTime = new string[12]
        { "00:00", "02:00", "04:00", "06:00", "08:00", "10:00", "12:00", "14:00", "16:00", "18:00", "20:00", "22:00"};

        public void LoadSheddingDuration(int num)
        {
            // Since there are 16 columns in load-shedding areas matrix match day 17 to day 31 with 1 to 16
            if (day == 17)
                day = 1;
            else if (day == 18)
                day = 2;
            else if (day == 19)
                day = 3;
            else if (day == 20)
                day = 4;
            else if (day == 21)
                day = 5;
            else if (day == 22)
                day = 6;
            else if (day == 23)
                day = 7;
            else if (day == 24)
                day = 8;
            else if (day == 25)
                day = 9;
            else if (day == 26)
                day = 10;
            else if (day == 27)
                day = 11;
            else if (day == 28)
                day = 12;
            else if (day == 29)
                day = 13;
            else if (day == 30)
                day = 14;
            else if (day == 31)
                day = 15;

            // Load-shedding Schedule
            Console.WriteLine("\nSTAGE 2 LOADSHEDDING SCHEDULE\n");

            for (int i = 0; i <= loadsheddingAreas.GetLength(0) - 1; i++)
            {
                if (num == loadsheddingAreas[i, day - 1])
                {
                    downTime = loadsheddingTime[i];
                    DateTime time = DateTime.ParseExact(downTime, "HH:mm", CultureInfo.InvariantCulture);

                    beginningTime = time.TimeOfDay;
                    endTime = (time.AddMinutes(150)).TimeOfDay;

                    Console.WriteLine($"{beginningTime} - {endTime}");
                }
                if (num == _loadsheddingAreas[i, day - 1])
                {
                    _downTime = _loadsheddingTime[i];
                    DateTime _time = DateTime.ParseExact(_downTime, "HH:mm", CultureInfo.InvariantCulture);

                    _beginningTime = _time.TimeOfDay;
                    _endTime = (_time.AddMinutes(150)).TimeOfDay;

                    Console.WriteLine($"{_beginningTime} - {_endTime}");
                }
            }

            Console.WriteLine(" ");
        }

        public void Result()
        {
            DateTime afterMidNightTime = DateTime.ParseExact("00:30:00", "HH:mm:ss", CultureInfo.InvariantCulture);
            var afterMidNight = afterMidNightTime.TimeOfDay;

            DateTime noTime = DateTime.ParseExact("00:00:00", "HH:mm:ss", CultureInfo.InvariantCulture);
            var emptyTime = noTime.TimeOfDay;

            DateTime halfPastTwo = DateTime.ParseExact("02:30:00", "HH:mm:ss", CultureInfo.InvariantCulture);
            var twoThirty = noTime.TimeOfDay;

            string currentTime = DateTime.Now.ToString("HH:mm:ss");
            DateTime currentTim = DateTime.ParseExact(currentTime, "HH:mm:ss", CultureInfo.InvariantCulture);
            var current = currentTim.TimeOfDay;

            string loadsheddingStartTime = beginningTime.ToString();
            string loadsheddingEndTime = endTime.ToString();

            DateTime startTime = DateTime.ParseExact(loadsheddingStartTime, "HH:mm:ss", CultureInfo.InvariantCulture);
            var start = startTime.TimeOfDay;
            DateTime endTimes = DateTime.ParseExact(loadsheddingEndTime, "HH:mm:ss", CultureInfo.InvariantCulture);
            var end = endTimes.TimeOfDay;

            string _loadsheddingStartTime = _beginningTime.ToString();
            string _loadsheddingEndTime = _endTime.ToString();

            DateTime _startTime = DateTime.ParseExact(_loadsheddingStartTime, "HH:mm:ss", CultureInfo.InvariantCulture);
            var _start = _startTime.TimeOfDay;
            DateTime _endTimes = DateTime.ParseExact(_loadsheddingEndTime, "HH:mm:ss", CultureInfo.InvariantCulture);
            var _end = _endTimes.TimeOfDay;

            // During loadshedding hours
            if ((current <= _start && current >= _end) && (start == emptyTime))
            {
                Console.WriteLine($"Your area is currently experiencing loadshedding it started at {_start} " +
                    $"and will end at {_end}, and there is no loadshedding scheduled after this tonight.");
            }
            else if ((current <= start && current >= end) && (_start == emptyTime))
            {
                Console.WriteLine($"Your area is currently experiencing loadshedding it started at {start} " +
                    $"and will end at {end}, and there is no loadshedding scheduled after this tonight.");
            }
            else if ((current >= start && current <= end) && (end < _start))
            {
                Console.WriteLine($"Your area is currently experiencing loadshedding it started at {start} " +
                    $"and will end at {end}. There is a loadshedding scheduled for {_start} until {_end}.");
            }
            else if ((current >= _start && current <= _end) && (_end < start))
            {
                Console.WriteLine($"Your area is currently experiencing loadshedding it started at {_start} " +
                    $"and will end at {_end}. There is a loadshedding scheduled for {start} until {end}.");
            }
            else if ((current >= start && current <= end) && (start > _end))
            {
                Console.WriteLine($"Your area is currently experiencing loadshedding it started at {start}" +
                    $" and will end at {end}, and there is no loadshedding scheduled after this tonight.");
            }
            else if ((current >= _start && current <= _end) && (_start > end))
            {
                Console.WriteLine($"Your area is currently experiencing loadshedding it started at {_start}" +
                    $" and will end at {_end}, and there is no loadshedding scheduled after this tonight.");
            }
            else if ((current >= start) && (end == afterMidNight))
            {
                Console.WriteLine($"Your area is currently experiencing loadshedding it started at {start} " +
                    $"and will end at {end}. There is no other loadshedding scheduled for tonight.");
            }
            else if ((current >= _start) && (_end == afterMidNight))
            {
                Console.WriteLine($"Your area is currently experiencing loadshedding it started at {start} " +
                    $"and will end at {end}. There is no other loadshedding scheduled for tonight.");
            }
            else if ((start == emptyTime) && (end == twoThirty))
            {
                Console.WriteLine($"Your area is currently experiencing load-shedding it start at {start} " +
                    $"and will end at {end}. There is a load-shedding scheduled for {_start} until {_end}.");
            }

            // Outside loadshedding hours
            else if ( (start == _start) && (current < start))
            {
                Console.WriteLine($"Your area is currently not experiencing load-shedding, however there is" +
                    $" load-shedding scheduled at {_start} until {_end}.");
            }
            else if ((start == _start) && (current > start))
            {
                Console.WriteLine("Your area is currently not experiencing any load-shedding, and there is" +
                    "no load-shedding scheduled today.");
            }
            else if ((current > end) && (current < _start))
            {
                Console.WriteLine($"Your area is currently not experiencing load-shedding, however there is" +
                    $" load-shedding scheduled at {_start} until {_end}.");
            }
            else if ((current < _start) && (end == emptyTime))
            {
                Console.WriteLine($"Your area is currently not experiencing any load-shedding, however there is" +
                    $" load-shedding scheduled at {_start} until {_end}.");
            }
            else if ((current > _end) && (end == emptyTime))
            {
                Console.WriteLine($"Your area is currently not experiencing any load-shedding, and there is " +
                    $"no load-shedding scheduled for today.");
            }
            else if ((current < start) && (_end == emptyTime))
            {
                Console.WriteLine($"Your area is currently not experiencing any load-shedding, however there is" +
                    $" loadshedding scheduled at {start} until {end}.");
            }
            else if ((current > end) && (end == emptyTime))
            {
                Console.WriteLine($"Your area is currently not experiencing any load-shedding, and there is" +
                    $" no load-shedding scheduled for today.");
            }
            else if ((current > end) && (current < _start) && (_end == afterMidNight))
            {
                Console.WriteLine($"Your area is currently not experiencing load-shedding, however there is " +
                    $"loadshedding scheduled at {_start} until {_end}.");
            }
            else if ((current < start) && (end < _start) && (end != afterMidNight))
            {
                Console.WriteLine($"Your area is currently not experiencing load-shedding, however there is " +
                    $"loadshedding scheduled at {start} until {end} and at {_start} until {_end}.");
            }
            else if ((current < start) && (end < _start) && (_end == afterMidNight))
            {
                Console.WriteLine($"Your area is currently not experiencing load-shedding, however there is" +
                    $" loadshedding scheduled at {start} until {end} and at {_start} until {_end}.");
            }
            else if ((current > _end && end < _start) && (end != afterMidNight) && (_end != afterMidNight))
            {
                Console.WriteLine($"Your area is currently not experiencing load-shedding and there are no " +
                    $"loashedding for scheduled tonight.");
            }
            else if ((current > _end) && (current < start))
            {
                Console.WriteLine($"Your area is currently not experiencing load-shedding, however there is" +
                    $" load-shedding scheduled at {start} until {end}.");
            }
            else if ((current > _end) && (current < start) && (end == afterMidNight))
            {
                Console.WriteLine($"Your area is currently not experiencing load-shedding, however there is" +
                    $" load-shedding scheduled at {_start} until {_end}");
            }
            else if ((current < _start) && (_end < start))
            {
                Console.WriteLine($"Your area is currently not experiencing load-shedding, however there is " +
                    $"load-shedding scheduled at {start} until {end} and at {_start} until {_end}.");
            }
            else if ((current < _start) && (_end < start) && (end == afterMidNight))
            {
                Console.WriteLine($"Your area is currently not experiencing load-shedding, however there is " +
                    $"load-shedding scheduled at {start} until {end} and at {_start} until {_end}.");
            }
            else if (current > end && (_end < start) && (end != afterMidNight) && (_end != afterMidNight))
            {
                Console.WriteLine($"Your area is currently not experiencing load-shedding and there is no " +
                    $"load-shedding scheduled for tonight.");
            }
        }
    }
}