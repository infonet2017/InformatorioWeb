using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoNET_LocalDB.Models
{
    public class Evaluation
{
    public int ID { get; set; }
    public string Name { get; set; }
    public DateTime DateEvaluation { get; set; }
    public virtual List<Feedback> Feedbacks {get; set;}
    public virtual Module Module { get; set; }

}
}
