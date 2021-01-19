using System;
using System.Collections.Generic;
using System.Text;
using ScrapySharp.Network;
using HtmlAgilityPack;
using Models;

namespace Helpers
{
    public class WebScrappingHelper
    {
        public List<HeadingDto> GetTextofHeadingTags(string url)
        {
            List<HeadingDto> headingDtos = new List<HeadingDto>();
            ScrapingBrowser Browser = new ScrapingBrowser();
            
            Browser.AllowAutoRedirect = true; 
            Browser.AllowMetaRedirect = true;
            
            WebPage PageResult = Browser.NavigateToPage(new Uri(url));
            HtmlNode TitleNode = PageResult.Html;
           
            string PageTitle = TitleNode.InnerHtml;
            HtmlDocument doc = new HtmlDocument();
            
            doc.LoadHtml(PageTitle);

            if(doc.DocumentNode.SelectNodes("//h1") != null)
            {
                foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//h1"))
                {
                    HeadingDto headingDto = new HeadingDto()
                    {
                        Content = node.InnerText,
                        HeadingType = "h1"
                    };

                    headingDtos.Add(headingDto);

                }
            }

            if (doc.DocumentNode.SelectNodes("//h2") != null)
            {
                foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//h2"))
                {
                    HeadingDto headingDto = new HeadingDto()
                    {
                        Content = node.InnerText,
                        HeadingType = "h2"
                    };

                    headingDtos.Add(headingDto);
                }
            }
            if (doc.DocumentNode.SelectNodes("//h3") != null)
            {
                foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//h3"))
                {
                    HeadingDto headingDto = new HeadingDto()
                    {
                        Content = node.InnerText,
                        HeadingType = "h3"
                    };

                    headingDtos.Add(headingDto);
                }
            }

            return headingDtos;
        }
    }
}
