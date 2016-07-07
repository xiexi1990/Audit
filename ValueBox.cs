using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audit
{
    public class ValueBox
    {
        private int _score_group = -1, _score_time = -1, _score_graph = -1, _score_log = -1, _score_gset = -1, _score_gsetclass = -1, _score_overanaly = -1, _score_missanaly = -1;
        private singleValueChanging score_group_changing = null, 
            score_time_changing = null, 
            score_graph_changing = null, 
            score_log_changing = null, 
            score_gset_changing = null,
            score_gsetclass_changing = null, 
            score_overanaly_changing = null, 
            score_missanaly_changing = null;
        public void SetDelegate(singleValueChanging score_group, singleValueChanging score_time, singleValueChanging score_graph, singleValueChanging score_log, singleValueChanging score_gset, singleValueChanging score_gsetclass, singleValueChanging score_overanaly, singleValueChanging score_missanaly)
        {
            this.score_group_changing = new singleValueChanging(score_group);
            this.score_time_changing = new singleValueChanging(score_time);
            this.score_graph_changing = new singleValueChanging(score_graph);
            this.score_log_changing = new singleValueChanging(score_log);
            this.score_gset_changing = new singleValueChanging(score_gset);
            this.score_gsetclass_changing = new singleValueChanging(score_gsetclass);
            this.score_overanaly_changing = new singleValueChanging(score_overanaly);
            this.score_missanaly_changing = new singleValueChanging(score_missanaly);
        }
        public int score_group
        {
            get { return _score_group; }
            set
            {
                if (value != _score_group)
                {                    
                    if(score_group_changing != null)
                        score_group_changing(value);
                    _score_group = value;
                }
            }
        }
        public int score_time
        {
            get { return _score_time; }
            set
            {
                if (value != _score_time)
                {
                    if (score_time_changing != null)
                        score_time_changing(value);
                    _score_time = value;
                }
            }
        }
        public int score_graph
        {
            get { return _score_graph; }
            set
            {
                if (value != _score_graph)
                {
                    if (score_graph_changing != null)
                        score_graph_changing(value);
                    _score_graph = value;
                }
            }
        }
        public int score_log
        {
            get { return _score_log; }
            set
            {
                if (value != _score_log)
                {
                    if (score_log_changing != null)
                        score_log_changing(value);
                    _score_log = value;
                }
            }
        }
        public int score_gset
        {
            get { return _score_gset; }
            set
            {
                if (value != _score_gset)
                {
                    if (score_gset_changing != null)
                        score_gset_changing(value);
                    _score_gset = value;
                }
            }
        }

        public int score_gsetclass
        {
            get { return _score_gsetclass; }
            set
            {
                if (value != _score_gsetclass)
                {
                    if (score_gsetclass_changing != null)
                        score_gsetclass_changing(value);
                    _score_gsetclass = value;
                }
            }
        }

        public int score_overanaly
        {
            get { return _score_overanaly; }
            set
            {
                if (value != _score_overanaly)
                {
                    if (score_overanaly_changing != null)
                        score_overanaly_changing(value);
                    _score_overanaly = value;
                }
            }
        }

        public int score_missanaly
        {
            get { return _score_missanaly; }
            set
            {
                if (value != _score_missanaly)
                {
                    if (score_missanaly_changing != null)
                        score_missanaly_changing(value);
                    _score_missanaly = value;
                }
            }
        }

    }
}
