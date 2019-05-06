using System;

namespace TeamBuddy.BL.Services
{
    public interface IMediator
    {
        void Register<TMessage>(Action<TMessage> action);
        void Send<TMessage>(TMessage message);
        void UnRegister<TMessage>(Action<TMessage> action);
    }
}
