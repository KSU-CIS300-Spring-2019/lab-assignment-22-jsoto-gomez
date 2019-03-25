using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithNoChildren : ITrie
    {
        /// <summary>
        ///  field to indicates whether the empty string is stored in the trie rooted at this node
        ///  this should be initially false
        /// </summary>
        private bool _hasEmptyString = false;

        /// <summary>
        /// Adds the given string to the trie rooted at this node.
        /// </summary>
        /// <param name="s">String to add</param>
        /// <returns>ITrie rooted at the node</returns>
        public ITrie Add(string s)
        {
            //throw new NotImplementedException();
            if (s == "")
            {
                _hasEmptyString = true;
                return this;
            }
            else
            {
                return new TrieWithOneChild(s, _hasEmptyString);
            }
           
        }
        /// <summary>
        /// Gets whether the trie rooted at this node contains the given string.
        /// </summary>
        /// <param name="s">The string to look up</param>
        /// <returns>Whether Trie rooted at this node contains s</returns>
        public bool Contains(string s)
        {
            //throw new NotImplementedException();
            if (s == "")
            {
                return _hasEmptyString;
            }
            else
            {
                return false;//string is not in the Trie
            }
        }
    }
}
