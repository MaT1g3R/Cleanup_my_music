using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;

namespace Cleanup_my_music {


    public class Song : TagLib.File {

        private string path;
        private string name;
        public string genre {
            get;
        }
        //what am i doing, i dont think anything in here works, please put me down

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="path">The path of said song</param>
        public Song(string path) : base(path) {
            this.path = path;
        }

        public override Tag Tag {
            get {
                throw new NotImplementedException();
            }
        }

        public override TagLib.Properties Properties {
            get {
                throw new NotImplementedException();
            }
        }


        public override void Save() {
            throw new NotImplementedException();
        }

        public override void RemoveTags(TagTypes types) {
            throw new NotImplementedException();
        }

        public override Tag GetTag(TagTypes type, bool create) {
            throw new NotImplementedException();
        }
    }
}
