using System;
using System.Collections.Generic;
using System.Text;
using TitanicPop.Domain.Contracts;
using TitanicPop.Domain.Entities;

namespace TitanicPop.Domain.Services
{
    public class TitanicPopService : ServiceBase<Passenger>, ITitanicPopService
    {
        private ITitanicPopRepository _titanicPopRepository;

        public TitanicPopService(ITitanicPopRepository titanicPopRepository)
            : base(titanicPopRepository)
        {
            _titanicPopRepository = titanicPopRepository;
        }
    }
}
