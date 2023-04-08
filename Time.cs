using System;
using System.Collections.Generic;
using System.Text;

namespace TimeClass
{
    class Time
    {
        public uint hours;
        public uint minutes;
        public uint seconds;
        public Time(uint hours = 0, uint minutes = 0, uint seconds = 0)
        {
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;

            // foreach (int value in (seconds, minutes))

            if (this.seconds > 60)
            {
                this.minutes += this.seconds / 60;
                this.seconds %= 60;
            }
            if (this.minutes > 60)
            {
                hours += this.minutes / 60;
                this.minutes %= 60;
            }
        }

        public static Time operator ++(Time a)
        {
            if (a.seconds == 59)
            {
                a.seconds = 0;
                a.minutes += 1;
            }
            else a.seconds += 1;
            return a;
        }
        public static Time operator --(Time a)
        {
            if (a.seconds == 0)
            {
                if (a.minutes == 0)
                {
                    if (a.hours == 0)
                    {
                        a.seconds = 0;
                    }
                    else
                    {
                        a.hours--;
                        a.minutes = 59;
                        a.seconds = 59;
                    }
                }
                else
                {
                    a.seconds = 59;
                    a.minutes -= 1;
                }
            }
            else a.seconds -= 1;
            return a;
        }
        public static Time operator +(Time a, Time b)
        {
            Time c = new Time(0, 0, 0);
            uint carryOver;

            c.seconds = a.seconds + b.seconds;
            if (c.seconds >= 60)
            {
                carryOver = c.seconds / 60;
                c.seconds %= 60;
            }
            else carryOver = 0;
            
            c.minutes = a.minutes + b.minutes + carryOver;
            if (c.minutes >= 60)
            {
                carryOver = c.minutes / 60;
                c.minutes %= 60;
            }
            else carryOver = 0;

            c.hours = a.hours + b.hours + carryOver;
            return c;
        }
        public static Time operator -(Time a, Time b)
        {
            Time c = new Time(0, 0, 0);
            int calcTemp;
            int carryOver;

            calcTemp = Convert.ToInt16(a.seconds - b.seconds);
            if (calcTemp < 0)
            {
                carryOver = calcTemp / 60;
                c.seconds = Convert.ToUInt16(60 - (calcTemp % 60));
            }
            else
            {
                carryOver = 0;
                c.seconds = Convert.ToUInt16(calcTemp);
            }

            calcTemp = Convert.ToInt16(a.minutes - b.minutes + carryOver);
            if (calcTemp < 0)
            {
                carryOver = calcTemp / 60;
                c.minutes = Convert.ToUInt16(60 - (calcTemp % 60));
            }
            else
            {
                carryOver = 0;
                c.minutes = Convert.ToUInt16(calcTemp);
            }

            calcTemp = Convert.ToInt16(a.hours + b.hours + carryOver);
            if (calcTemp < 0) c = new Time(0, 0, 0);
            else c.hours = Convert.ToUInt16(calcTemp);

            return c;
        }

        public static bool operator >(Time a, Time b)
        {
            bool result;
            if (a.hours > b.hours) result = true;
            else if (a.hours == b.hours)
            {
                if (a.minutes > b.minutes) result = true;
                else if (a.minutes == b.minutes)
                {
                    if (a.seconds > b.seconds) result = true;
                    else result = false;
                }
                else result = false;
            }
            else result = false;
                
            return result;
        }
        public static bool operator <(Time a, Time b) => !(a > b);

        public static bool operator ==(Time a, Time b)
        {
            bool result;

            if (a.hours == b.hours && a.minutes == b.minutes && a.seconds == b.seconds)
            {
                result = true;
            }
            else result = false;

            return result;
        }
        public static bool operator !=(Time a, Time b) => !(a == b);

        public void Print()
        {
            Console.Write($"Time is {this.hours}:{this.minutes}:{this.seconds}");
            Console.WriteLine();
        }
    }
}
