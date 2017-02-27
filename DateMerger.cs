using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audit
{
    public class DatePair
    {
        public DateTime begin, end;
        public DatePair(){}
        public DatePair(DateTime begin, DateTime end) { this.begin = begin; this.end = end; }
    }
    public enum DateMergerPrecision
    {
        Day = 1, Hour = 2, Minute = 3, Second = 4
    }
    
    public class DateMerger
    {
        public DateTime _begin, _end;
        public DateMergerPrecision _p;
        public DateMerger(DateTime begin, DateTime end, DateMergerPrecision p) 
        { 
            _p = p;
            if (_p == DateMergerPrecision.Day)
            {
                _begin = new DateTime(begin.Year, begin.Month, begin.Day, 0, 0, 0);
                _end = new DateTime(end.Year, end.Month, end.Day, 0, 0, 0).AddDays(1);
            }
            else if (_p == DateMergerPrecision.Hour)
            {
                _begin = new DateTime(begin.Year, begin.Month, begin.Day, begin.Hour, 0, 0);
                _end = new DateTime(end.Year, end.Month, end.Day, end.Hour, 0, 0).AddHours(1);
            }
            else if (_p == DateMergerPrecision.Minute)
            {
                _begin = new DateTime(begin.Year, begin.Month, begin.Day, begin.Hour, begin.Minute, 0);
                _end = new DateTime(end.Year, end.Month, end.Day, end.Hour, end.Minute, 0).AddMinutes(1);
            }
            else if (_p == DateMergerPrecision.Second)
            {
                _begin = begin;
                _end = end;
            }
        }
        List<DatePair> dlist = new List<DatePair>();
        public void Merge(DatePair datepair)
        {
            if(datepair.begin > datepair.end)
            {
                Console.WriteLine("error in DateMerger.Merge: datepair.begin > datepair.end");
                return;
            }
            DatePair _datepair = new DatePair();
            if (_p == DateMergerPrecision.Day)
            {
                _datepair.begin = new DateTime(datepair.begin.Year, datepair.begin.Month, datepair.begin.Day, 0, 0, 0);
                _datepair.end = new DateTime(datepair.end.Year, datepair.end.Month, datepair.end.Day, 0, 0, 0).AddDays(1);
            }
            else if (_p == DateMergerPrecision.Hour)
            {
                _datepair.begin = new DateTime(datepair.begin.Year, datepair.begin.Month, datepair.begin.Day, datepair.begin.Hour, 0, 0);
                _datepair.end = new DateTime(datepair.end.Year, datepair.end.Month, datepair.end.Day, datepair.end.Hour, 0, 0).AddHours(1);
            }
            else if (_p == DateMergerPrecision.Minute)
            {
                _datepair.begin = new DateTime(datepair.begin.Year, datepair.begin.Month, datepair.begin.Day, datepair.begin.Hour, datepair.begin.Minute, 0);
                _datepair.end = new DateTime(datepair.end.Year, datepair.end.Month, datepair.end.Day, datepair.end.Hour, datepair.end.Minute, 0).AddMinutes(1);
            }
            else if (_p == DateMergerPrecision.Second)
            {
                _datepair.begin = datepair.begin;
                _datepair.end = datepair.end;
            }
  
            if (_datepair.begin < _begin)
            {
                _datepair.begin = _begin;
            }
            if (_datepair.end > _end)
            {
                _datepair.end = _end;
            }

            if (_datepair.begin > _datepair.end)
            {
                Console.WriteLine("improper _end");
                throw new Exception();
            }

            if (dlist.Count == 0)
            {
                dlist.Add(_datepair);
                return;
            }
            if (dlist.Count == 1)
            {
                if (dlist[0].begin == _begin && dlist[0].end == _end)
                    return;
            }

            int beginloc = -1;
            for (int i = 0; i < dlist.Count; i++)
            {
                if (_datepair.begin < dlist[i].begin)
                {
                    beginloc = i * 2;
                    break;
                }
                else if (dlist[i].begin <= _datepair.begin && _datepair.begin <= dlist[i].end.AddSeconds(1))
                {
                    beginloc = i * 2 + 1;
                    break;
                }
            }
            if (beginloc == -1)
            {
                beginloc = dlist.Count * 2;
            }

            int endloc = -1;
            for (int i = 0; i < dlist.Count; i++)
            {
                if (_datepair.end < dlist[i].begin.AddSeconds(-1))
                {
                    endloc = i * 2;
                    break;
                }
                else if (dlist[i].begin.AddSeconds(-1) <= _datepair.end && _datepair.end <= dlist[i].end)
                {
                    endloc = i * 2 + 1;
                    break;
                }
            }
            if (endloc == -1)
            {
                endloc = dlist.Count * 2;
            }

            DateTime begin_insert, end_insert;
            bool beginstick, endstick;

            if (beginloc % 2 == 0)
            {
                begin_insert = _datepair.begin;
                beginstick = false;
            }
            else
            {
                begin_insert = dlist[beginloc / 2].begin;
                beginstick = true;
            }

            if (endloc % 2 == 0)
            {
                end_insert = _datepair.end;
                endstick = false;
            }
            else
            {
                end_insert = dlist[endloc / 2].end;
                endstick = true;
            }
            int del1 = beginloc / 2;
            int del2;
            if(endloc == 0)
            {
                del2 = -1;
            }
            else
            {
                del2 = (endloc - 1) / 2;
            }
            dlist.RemoveRange(del1, del2 - del1 + 1);
            dlist.Insert(del1, new DatePair(begin_insert, end_insert));
        }
        public double CalComp()
        {
            double totalsec = 0;
            for (int i = 0; i < dlist.Count; i++)
            {
                totalsec += (dlist[i].end - dlist[i].begin).TotalSeconds;
            }
            return totalsec / (_end - _begin).TotalSeconds;
        }
    }
}
