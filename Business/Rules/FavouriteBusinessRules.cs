using Core.Business.Rules;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class FavouriteBusinessRules : BaseBusinessRules<Favourite>
    {
        IFavouriteDal _favouriteDal;
        public FavouriteBusinessRules(IFavouriteDal favouriteDal) : base(favouriteDal) 
        {
            _favouriteDal = favouriteDal;
        }
    }
}
