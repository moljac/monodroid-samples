using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;

namespace FlashCardPager
{
    class FlashCardDeckAdapter : FragmentPagerAdapter
    {
        // Underlying model data (flash card deck):
        public FlashCardDeck flashCardDeck;

        // Constructor accepts a deck of flash cards:
        public FlashCardDeckAdapter(AndroidX.Fragment.App.FragmentManager fm, FlashCardDeck flashCards) 
            : base(fm)
        {
            this.flashCardDeck = flashCards;
        }

        // Returns the number of cards in the deck:
        public override int Count { get { return flashCardDeck.NumCards; } }

        // Returns a new fragment for the flash card at this position:
        public override AndroidX.Fragment.App.Fragment GetItem(int position)
        {
            return (AndroidX.Fragment.App.Fragment)
                FlashCardFragment.newInstance(flashCardDeck[position].Problem, flashCardDeck[position].Answer);
        }

        // Display the problem number in the PagerTitleStrip:
        public override Java.Lang.ICharSequence GetPageTitleFormatted(int position)
        {
            return new Java.Lang.String("Problem " + (position + 1));
        }
    }
}