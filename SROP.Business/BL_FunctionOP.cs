
using Oracle.DataAccess.Client;

using System.IO;
using System.Linq;

	public class BL_FunctionOP : BL_BASE
	{

		public byte[] SimboloEnBytes(string ImgFilePath)
		{
			byte[] functionReturnValue = null;

			functionReturnValue = null;
			DirectoryInfo dirInfo = new DirectoryInfo(ImgFilePath);

			if (dirInfo.Exists) {
				foreach (FileInfo xFileInfo in dirInfo.GetFiles("*.jpg").OrderBy(p => p.CreationTime).ToArray()) {
					functionReturnValue = PutImage(ImgFilePath + xFileInfo.Name);
				}
			}
			return functionReturnValue;

		}

		

		public byte[] PutImage(string sImageNamePath)
		{
			System.IO.FileStream oImg = null;
			System.IO.BinaryReader oBinaryReader = null;
			byte[] oImgByteArray = null;

			oImg = new System.IO.FileStream(sImageNamePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);

			oBinaryReader = new System.IO.BinaryReader(oImg);
			oImgByteArray = oBinaryReader.ReadBytes((int)oImg.Length);

			oImg.Read(oImgByteArray, 0, (int)oImg.Length);

			oBinaryReader.Close();
			oImg.Close();

			return oImgByteArray;
		}
	}

