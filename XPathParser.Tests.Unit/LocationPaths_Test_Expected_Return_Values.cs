using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodePlex.XPathParser;

namespace XPathParser.Tests.Unit {

    [TestClass]
    public class LocationPaths_Test_Expected_Return_Values {

        [TestMethod]
        public void Test_All_Items_For_Correct_Return_Paths() {

            var values = new List<KeyValuePair<string, string>>() {
                new KeyValuePair<string,string>("/" , "root::node()"),
                new KeyValuePair<string,string>("/child::doc/child::chapter[position()=5]/child::section[position()=2]" , "root::node()/child::doc/(child::chapter)[position()=5]/(child::section)[position()=2]"),
                new KeyValuePair<string,string>("/descendant::figure[position()=42]" , "root::node()/(descendant::figure)[position()=42]"),
                new KeyValuePair<string,string>("/descendant::olist/child::item" , "root::node()/descendant::olist/child::item"),
                new KeyValuePair<string,string>("/descendant::para" , "root::node()/descendant::para"),
                new KeyValuePair<string,string>("ancestor-or-self::div" , "ancestor-or-self::div"),
                new KeyValuePair<string,string>("ancestor::div" , "ancestor::div"),
                new KeyValuePair<string,string>("attribute::*" , "attribute::*"),
                new KeyValuePair<string,string>("attribute::name" , "attribute::name"),
                new KeyValuePair<string,string>("child::*" , "child::*"),
                new KeyValuePair<string,string>("child::*/child::para" , "child::*/child::para"),
                new KeyValuePair<string,string>("child::*[self::chapter or self::appendix]" , "(child::*)[self::chapter or self::appendix]"),
                new KeyValuePair<string,string>("child::*[self::chapter or self::appendix][position()=last()]" , "((child::*)[self::chapter or self::appendix])[position()=last()]"),
                new KeyValuePair<string,string>("child::chapter/descendant::para" , "child::chapter/descendant::para"),
                new KeyValuePair<string,string>("child::chapter[child::title='Introduction']" , "(child::chapter)[child::title='Introduction']"),
                new KeyValuePair<string,string>("child::chapter[child::title]" , "(child::chapter)[child::title]"),
                new KeyValuePair<string,string>("child::node()" , "child::node()"),
                new KeyValuePair<string,string>("child::para" , "child::para"),
                new KeyValuePair<string,string>("child::para[attribute::type='warning']" , "(child::para)[attribute::type='warning']"),
                new KeyValuePair<string,string>("child::para[attribute::type='warning'][position()=5]" , "((child::para)[attribute::type='warning'])[position()=5]"),
                new KeyValuePair<string,string>("child::para[position()=1]" , "(child::para)[position()=1]"),
                new KeyValuePair<string,string>("child::para[position()=5][attribute::type='warning']" , "((child::para)[position()=5])[attribute::type='warning']"),
                new KeyValuePair<string,string>("child::para[position()=last()-1]" , "(child::para)[position()=last()-1]"),
                new KeyValuePair<string,string>("child::para[position()=last()]" , "(child::para)[position()=last()]"),
                new KeyValuePair<string,string>("child::para[position()>1]" , "(child::para)[position()>1]"),
                new KeyValuePair<string,string>("child::text()" , "child::text()"),
                new KeyValuePair<string,string>("descendant-or-self::para" , "descendant-or-self::para"),
                new KeyValuePair<string,string>("descendant::para" , "descendant::para"),
                new KeyValuePair<string,string>("following-sibling::chapter[position()=1]" , "(following-sibling::chapter)[position()=1]"),
                new KeyValuePair<string,string>("preceding-sibling::chapter[position()=1]" , "preceding-sibling::chapter[position()=1]"),
                new KeyValuePair<string,string>("self::para" , "self::para")
                };

            foreach (var item in values) {
                var result = new XPathParser<string>().Parse(item.Key, new XPathStringBuilder());
                Assert.AreEqual<string>(item.Value, result);
            }

        }

        [TestMethod]
        public void Test_All_Items_For_Correct_Return_Paths_Abbreviated_Syntax() {

            var values = new List<KeyValuePair<string, string>>() {
                new KeyValuePair<string,string>("/" , "root::node()"),
                new KeyValuePair<string,string>("/doc/chapter[position()=5]/section[position()=2]" , "root::node()/child::doc/(child::chapter)[position()=5]/(child::section)[position()=2]"),
                new KeyValuePair<string,string>("@*" , "attribute::*"),
                new KeyValuePair<string,string>("@name" , "attribute::name"),
                new KeyValuePair<string,string>("*" , "child::*"),
                new KeyValuePair<string,string>("*/child::para" , "child::*/child::para"),
                new KeyValuePair<string,string>("*[self::chapter or self::appendix]" , "(child::*)[self::chapter or self::appendix]"),
                new KeyValuePair<string,string>("*[self::chapter or self::appendix][position()=last()]" , "((child::*)[self::chapter or self::appendix])[position()=last()]"),
                new KeyValuePair<string,string>("chapter/descendant::para" , "child::chapter/descendant::para"),
                new KeyValuePair<string,string>("chapter[title='Introduction']" , "(child::chapter)[child::title='Introduction']"),
                new KeyValuePair<string,string>("chapter[title]" , "(child::chapter)[child::title]"),
                new KeyValuePair<string,string>("node()" , "child::node()"),
                new KeyValuePair<string,string>("para" , "child::para"),
                new KeyValuePair<string,string>("para[@type='warning']" , "(child::para)[attribute::type='warning']"),
                new KeyValuePair<string,string>("para[@type='warning'][position()=5]" , "((child::para)[attribute::type='warning'])[position()=5]"),
                new KeyValuePair<string,string>("para[1]" , "(child::para)[1]"),
                new KeyValuePair<string,string>("para[position()=5][@type='warning']" , "((child::para)[position()=5])[attribute::type='warning']"),
                new KeyValuePair<string,string>("para[position()=last()-1]" , "(child::para)[position()=last()-1]"),
                new KeyValuePair<string,string>("para[position()=last()]" , "(child::para)[position()=last()]"),
                new KeyValuePair<string,string>("para[position()>1]" , "(child::para)[position()>1]"),
                new KeyValuePair<string,string>("text()" , "child::text()"),
                };

            foreach (var item in values) {
                var result = new XPathParser<string>().Parse(item.Key, new XPathStringBuilder());
                Assert.AreEqual<string>(item.Value, result);
            }

        }

    }
}
