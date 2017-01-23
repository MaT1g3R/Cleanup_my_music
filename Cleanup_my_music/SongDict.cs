using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TagLib;

namespace Cleanup_my_music {
    class SongDict {
        private Dictionary<string, object> dict;

        public SongDict() { }

        public void addSong(File f) {
            var songType = f.GetType();
            var Tag = songType.GetProperty("Tag");
            var Properties = songType.GetProperty("Properties");

            var allTags = Tag.GetValue(f);
            Tag allTagsCast = (Tag)allTags;
            var tagType = allTagsCast.GetType();
            var tags = tagType.GetProperties();

            var allProperties = Properties.GetValue(f);
            TagLib.Properties allPropertiesCast = (TagLib.Properties)allProperties;
            var propertiesType = allPropertiesCast.GetType();
            var properties = propertiesType.GetProperties();


            List<string> tagNames = new List<string> { };
            List<string> propertyNames = new List<string> { };

            foreach (PropertyInfo info in tags) {
                if (info.GetSetMethod() != null && info.GetGetMethod() != null) {
                    tagNames.Add(info.Name);
                }
            }

            foreach (PropertyInfo info in properties) {
                if (info.GetGetMethod() != null) {
                    propertyNames.Add(info.Name);
                }
            }

            Dictionary<string, object> myDict = new Dictionary<string, object> { };

            foreach (string tagname in tagNames) {
                var tag = tagType.GetProperty(tagname);
                var mySongTag = tag.GetGetMethod().Invoke(allTagsCast, null);
                myDict.Add(tagname, mySongTag);
            }

            foreach (string propertyName in propertyNames) {
                var property = propertiesType.GetProperty(propertyName);
                var mySongproperty = property.GetGetMethod().Invoke(allPropertiesCast, null);
                myDict.Add(propertyName, mySongproperty);
            }

        }
    }

}