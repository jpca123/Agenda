using System;

namespace Agenda.Dominio
{
  public class Event
  {
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string date { get; set; }
    public string duration { get; set; }
    public User user  { get; set; }
  }
}