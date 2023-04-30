using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;


//public class TimeLine
//{
//    private List<Move> _moves;
//    private SortedSet<TimeFrame> _timeFrames;

//    public IEnumerable<TimeFrame> GetTimeFrames => _timeFrames;

//    public TimeLine(Map map)
//    {
//        TimeFrame firstFrame = new TimeFrame(map);
//        _timeFrames = new SortedSet<TimeFrame>() { firstFrame };
//        _moves = new List<Move>();
//    }

//    private void ChangeFuture(TimeFrame timeFrame)
//    {
//        TimeFrame[] futureTimeFrames = _timeFrames.MoreThat(timeFrame).ToArray();
//        //Map map = timeFrame.MapCopy;


//    }

//    public void ApplyMove(Move move, int time)
//    {
//        TimeFrame timeFrame = _timeFrames.Where( f => f.Time == time).FirstOrDefault();
//        if (timeFrame == null)
//            throw new ArgumentException();

//        _moves.SetWithExpandIfNecessary(time, move);

//        timeFrame.ApplyMove(move);

//        //if(move is TimeTravelMove timeTravelMove)
//        //{
//        //    int nextTime = time + timeTravelMove.TimeOffset;
//        //    if (_timeFrames.Where(f => f.Time == nextTime).Any() == false)
//        //    {

//        //    }



            


//        //}

//        ChangeFuture(timeFrame);
//    }
//}

