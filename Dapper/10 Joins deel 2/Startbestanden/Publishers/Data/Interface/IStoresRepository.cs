﻿using Publishers.Models;
using System;
using System.Collections.Generic;

namespace Publishers.Data.Interface
{
    public interface IStoresRepository
    {
        public IEnumerable<Store> OphalenStoresSalesBoeken();

        public List<Store> OphalenStoresViaStaat(string stad);

        public List<Store> OphalenStoresViaNaam(string naam);

        public List<Store> OphalenStoresViaNaamEnStaat(string naam, string stad);

        public Store OphalenStoreViaId(int id);

       
    }
}