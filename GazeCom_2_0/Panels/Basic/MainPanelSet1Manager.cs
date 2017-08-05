using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GazeCom_2_0.Panels.Basic
{
    public class MainPanelSet1Manager
    {
        private int _currIndex;
        private readonly List<UserControl> _mainPanels;

        public MainPanelSet1Manager()
        {
            _mainPanels = new List<UserControl>
            {
                new YesNoPanel(),
                new BasicQuestions1(),
                new BasicSelfExpression()
            };

            _currIndex = 0;
        }

        public bool HasPanel()
        {
            return _mainPanels.Any();
        }

        public UserControl GetCurrentPanel()
        {
            return _mainPanels.ElementAt(_currIndex);
        }

        public UserControl GetPanel(int index)
        {
            return _mainPanels.ElementAt(index);
        }

        public UserControl GetNextPanel(bool isInCycle)
        {
            if(_currIndex < _mainPanels.Count - 1)
                ++_currIndex;
            else if (isInCycle)
                _currIndex = 0;

            return GetPanel(_currIndex);
        }

        public UserControl GetPreviousPanel(bool isInCycle)
        {
            if(_currIndex > 0)
                --_currIndex;
            else if (isInCycle)
                _currIndex = _mainPanels.Count - 1;

            return GetPanel(_currIndex);
        }


    }
}
