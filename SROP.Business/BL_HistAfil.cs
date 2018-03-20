using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;


	public class BL_HistAfil : BL_BASE
	{


        private DA_HistAfil data;
        public string UpdateFlagsComites_Personeros(BE_HistAfil c)
		{
        return data.UpdateFlagsComites_Personeros(c);
    }

        public BL_HistAfil() { data = new DA_HistAfil(); }
        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                data.Dispose(); data = null;
            }
            disposed = true;
            base.Dispose(disposing);
        }
    }

