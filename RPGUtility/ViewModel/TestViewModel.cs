using RPGUtility.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtility.ViewModel
{
    class TestViewModel
    {
        private Character _character;
        public TestViewModel(Character character)
        {
            _character = character;   
        }
    }
}
