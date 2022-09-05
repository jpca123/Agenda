using System;
using System.Collections.Generic;
using System.Linq;
using Agenda.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Persistencia
{
  public class EventRepository : IEventRepository
  {
    private readonly AppContext _appContext;

    public EventRepository(AppContext context){
      _appContext = context;
    }

    int IEventRepository.Add(Event _event){
      _appContext.Events.Add(_event);
      return _appContext.SaveChanges();
    }

    Event IEventRepository.Get(int id){
      return _appContext.Events.Find(id);

    }

    IEnumerable<Event> IEventRepository.FindByName(string name){
      return _appContext.Events.Where(e => e.name.Contains(name));
    }

    List<Event> IEventRepository.GetAll(){
      return _appContext.Events.ToList();
    }

    bool IEventRepository.Update(Event oldEvent){
      var eventFind = _appContext.Events.Find(oldEvent.id);
      if(eventFind == null) return false;

      eventFind.name = oldEvent.name;
      eventFind.description = oldEvent.description;
      eventFind.date = oldEvent.date;
      eventFind.duration = oldEvent.duration;
      eventFind.user = oldEvent.user;

      return _appContext.SaveChanges() > 0 ? true : false;
    }

    bool IEventRepository.Delete(int id){
      var eventFind = _appContext.Events.Find(id);
      if (eventFind == null) return false;

      _appContext.Events.Remove(eventFind);

      return _appContext.SaveChanges() > 0 ? true :false;
    }

  }
}