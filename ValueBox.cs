﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audit
{
    public class ValueBox
    {
        private int _score_group = -1, _score_time = -1, _score_graph = -1, _score_log = -1;
        private singleValueChanging score_group_changing = null, 
            score_time_changing = null, 
            score_graph_changing = null, 
            score_log_changing = null;
        public void SetDelegate(singleValueChanging score_group, singleValueChanging score_time, singleValueChanging score_graph, singleValueChanging score_log)
        {
            this.score_group_changing = new singleValueChanging(score_group);
            this.score_time_changing = new singleValueChanging(score_time);
            this.score_graph_changing = new singleValueChanging(score_graph);
            this.score_log_changing = new singleValueChanging(score_log);
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
    }
}
