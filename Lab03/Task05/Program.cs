﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task05
{
    public abstract class LightNode
    {
        public abstract string OuterHtml { get; }
        public abstract string InnerHtml { get; }
    }

    public class LightTextNode : LightNode
    {
        public string Text { get; set; }

        public LightTextNode(string text)
        {
            Text = text;
        }

        public override string OuterHtml => Text;
        public override string InnerHtml => Text;
    }

    public class LightElementNode : LightNode
    {
        public string TagName { get; set; }
        public bool IsBlock { get; set; } 
        public bool IsSelfClosing { get; set; } 
        public List<string> CssClasses { get; set; } 
        public List<LightNode> Children { get; set; } 

        public LightElementNode(string tagName, bool isBlock = true, bool isSelfClosing = false)
        {
            TagName = tagName;
            IsBlock = isBlock;
            IsSelfClosing = isSelfClosing;
            CssClasses = new List<string>();
            Children = new List<LightNode>();
        }

        public override string OuterHtml
        {
            get
            {
                string classes = CssClasses.Count > 0 ? $" class=\"{string.Join(" ", CssClasses)}\"" : string.Empty;
                string startTag = $"<{TagName}{classes}>";
                string endTag = IsSelfClosing ? " />" : $"</{TagName}>";

                if (Children.Count == 0)
                    return IsSelfClosing ? $"<{TagName}{classes} />" : $"{startTag}{endTag}";

                return $"{startTag}{InnerHtml}{endTag}";
            }
        }

        public override string InnerHtml
        {
            get
            {
                List<string> childrenHtml = new List<string>();
                foreach (var child in Children)
                {
                    childrenHtml.Add(child.OuterHtml);
                }
                return string.Join("", childrenHtml);
            }
        }

        public void AddChild(LightNode child)
        {
            Children.Add(child);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            LightElementNode div = new LightElementNode("div", true);
            div.CssClasses.Add("container");
            div.CssClasses.Add("main");

            LightElementNode ul = new LightElementNode("ul", true);
            LightElementNode li1 = new LightElementNode("li", false);
            li1.AddChild(new LightTextNode("Пункт 1"));
            LightElementNode li2 = new LightElementNode("li", false);
            li2.AddChild(new LightTextNode("Пункт 2"));

            ul.AddChild(li1);
            ul.AddChild(li2);

            LightTextNode textNode = new LightTextNode("Це просто текст в блоці div!");

            div.AddChild(textNode);
            div.AddChild(ul);

            Console.WriteLine(div.OuterHtml);

            Console.ReadKey();
        }
    }

}
