using System;
using System.Collections.Generic;
using Agenda.Dominio;

namespace Agenda.Persistencia
{
  public interface IEventRepository
  {
    int Add(Event _event);

    Event Get(int id);

    List<Event> GetAll();

    IEnumerable<Event> FindByName(string name);

    bool Update(Event oldEvent);

    bool Delete(int id);

  }
}