using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithOneChild : ITrie
    {
        /// <summary>
        /// Field defines whether the trie contains the empty string
        /// </summary>
        private bool _hasEmptyString;

        /// <summary>
        /// Field defines the ONLY child as an ITrie since one cannot know which implementation it might be
        /// </summary>
        private ITrie _child;

        /// <summary>
        /// Field defines the nodes label
        /// </summary>
        private char _childLabel;

        /// <summary>
        /// Constructor for a Trie with 1 Child
        /// </summary>
        /// <param name="s">string to be stored</param>
        /// <param name="isEmpty">idicates whether the string is to be stored</param>
        public TrieWithOneChild(string s, bool isEmpty)
        {
            if(s == "" || s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            _hasEmptyString = isEmpty;
            _childLabel = s[0];
            _child = new TrieWithNoChildren();
            _child = _child.Add(s.Substring(1));
        }

        /// <summary>
        /// Adds the given string to the trie rooted at this node.
        /// </summary>
        /// <param name="s">The string to add</param>
        /// <returns>ITrie rooted at the node</returns>
        public ITrie Add(string s)
        {
            //throw new NotImplementedException();
            if(s == "")
            {
               _hasEmptyString = true;
                return this;
            }
            else if(s[0] == _childLabel)
            {
                _child = _child.Add(s.Substring(1));//recursively look up child then Change ITrie 
                return this;
            }
            else//non-empty string whose 1st character doesn't match child's label
            {
                return new TrieWithManyChildren(s, _hasEmptyString, _childLabel, _child);
            }
        }
        /// <summary>
        /// Gets whether the trie rooted at this node contains the given string.
        /// </summary>
        /// <param name="s">The string to look up</param>
        /// <returns>Whether Trie rooted at this node contains s</returns>
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _hasEmptyString;
            }
            else
            {
                return _child.Contains(s.Substring(1));
            }
        }
    }
}
