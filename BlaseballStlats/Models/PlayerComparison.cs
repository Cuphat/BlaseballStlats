using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlaseballStlats.Models
{
    public class PlayerComparison
    {
        public double Buoyancy { get; set; }

        public double Divinity { get; set; }

        public double Martyrdom { get; set; }

        public double Moxie { get; set; }

        public double Musclitude { get; set; }

        public double Patheticism { get; set; }

        public double Thwackability { get; set; }

        public double Tragicness { get; set; }

        public double Coldness { get; set; }

        public double Overpowerment { get; set; }

        public double Ruthlessness { get; set; }

        public double Shakespearianism { get; set; }

        public double Suppression { get; set; }

        public double Unthwackability { get; set; }

        public int TotalFingers { get; set; }

        public double BaseThirst { get; set; }

        public double Continuation { get; set; }

        public double GroundFriction { get; set; }

        public double Indulgence { get; set; }

        public double Laserlikeness { get; set; }

        public double Anticapitalism { get; set; }

        public double Chasiness { get; set; }

        public double Omniscience { get; set; }

        public double Tenaciousness { get; set; }

        public double Watchfulness { get; set; }

        public double Cinnamon { get; set; }

        public int Fate { get; set; }

        public double Pressurization { get; set; }

        public int Soul { get; set; }

        public double EDensity { get; set; }

        public double BattingStars { get; set; }

        public double PitchingStars { get; set; }

        public double BaserunningStars { get; set; }

        public double DefenseStars { get; set; }

        public PlayerComparison() { }

        public PlayerComparison(Player player1, Player player2)
        {
            Buoyancy = player1.Buoyancy - player2.Buoyancy;
            Divinity = player1.Divinity = player2.Divinity;
            Martyrdom = player1.Martyrdom = player2.Martyrdom;
            Moxie = player1.Moxie - player2.Moxie;
            Musclitude = player1.Musclitude - player2.Musclitude;
            Patheticism = player1.Patheticism - player2.Patheticism;
            Thwackability = player1.Thwackability - player2.Thwackability;
            Tragicness = player1.Tragicness - player2.Tragicness;

            Coldness = player1.Coldness - player2.Coldness;
            Overpowerment = player1.Overpowerment - player2.Overpowerment;
            Ruthlessness = player1.Ruthlessness - player2.Ruthlessness;
            Shakespearianism = player1.Shakespearianism - player2.Shakespearianism;
            Suppression = player1.Suppression - player2.Suppression;
            Unthwackability = player1.Unthwackability - player2.Unthwackability;
            TotalFingers = player1.TotalFingers - player2.TotalFingers;

            BaseThirst = player1.BaseThirst - player2.BaseThirst;
            Continuation = player1.Continuation - player2.Continuation;
            GroundFriction = player1.GroundFriction - player2.GroundFriction;
            Indulgence = player1.Indulgence - player2.Indulgence;
            Laserlikeness = player1.Laserlikeness - player2.Laserlikeness;

            Anticapitalism = player1.Anticapitalism - player2.Anticapitalism;
            Chasiness = player1.Chasiness - player2.Chasiness;
            Omniscience = player1.Omniscience - player2.Omniscience;
            Tenaciousness = player1.Tenaciousness - player2.Tenaciousness;
            Watchfulness = player1.Watchfulness - player2.Watchfulness;

            Cinnamon = player1.Cinnamon - player2.Cinnamon;
            Fate = player1.Fate - player2.Fate;
            Pressurization = player1.Pressurization - player2.Pressurization;
            Soul = player1.Soul - player2.Soul;

            BattingStars = player1.BattingStars - player2.BattingStars;
            PitchingStars = player1.PitchingStars - player2.PitchingStars;
            BaserunningStars = player1.BaserunningStars - player2.BaserunningStars;
            DefenseStars = player1.DefenseStars - player2.DefenseStars;
        }
    }
}
