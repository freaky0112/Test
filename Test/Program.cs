// //
// //                       _oo0oo_
// //                      o8888888o
// //                      88" . "88
// //                      (| -_- |)
// //                      0\  =  /0
// //                    ___/`---'\___
// //                  .' \\|     |// '.
// //                 / \\|||  :  |||// \
// //                / _||||| -:- |||||- \
// //               |   | \\\  -  /// |   |
// //               | \_|  ''\---/''  |_/ |
// //               \  .-\__  '-'  ___/-. /
// //             ___'. .'  /--.--\  `. .'___
// //          ."" '<  `.___\_<|>_/___.' >' "".
// //         | | :  `- \`.;`\ _ /`;.`/ - ` : | |
// //         \  \ `_.   \_ __\ /__ _/   .-` /  /
// //     =====`-.____`.___ \_____/___.-`___.-'=====
// //                       `=---='
// //
// //
// //     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
// //
// //               佛祖保佑         永无BUG
// //
// //
// //
using System;
using DotSpatial.Data;
using System.Data;

namespace Test {
	class MainClass {
		public static void Main(string[] args) {
			IFeatureSet fsouce = FeatureSet.Open("");
			fsouce.DataTable.Columns.Add(new DataColumn("DJC",typeof(int)));
			for(int i = 0; i < fsouce.Features.Count; i++) {
				IFeature feature = fsouce.Features[i];
				double lyxs = double.Parse(feature.DataRow["LYXS"].ToString());
				string trzd = feature.DataRow["BCTRZDZ"].ToString();
				string hb = feature.DataRow["HBGDZ"].ToString();
				int best = Calculate.ToGJLYDZS(lyxs, trzd, hb);
				int gjlyd = Int32.Parse(feature.DataRow["GJLYD"].ToString());
				feature.DataRow.BeginEdit();
				feature.DataRow["DJC"] = gjlyd - best;
				feature.DataRow.EndEdit();
			}
			fsouce.SaveAs("edit.shp", true);
			fsouce.Dispose();
		}
	}
}
