﻿using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        public IResult Add(Entities.Concrete.Color color)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Entities.Concrete.Color color)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Entities.Concrete.Color>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Entities.Concrete.Color> GetById(int colorId)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Entities.Concrete.Color color)
        {
            throw new NotImplementedException();
        }
    }
}
