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
using IronRuby;

namespace Test {
	public class Calculate {
		public Calculate() {
		}

		public static int ToGJLYDZS(double lyxs,string trzd,string hb){
			int gjtydzs = 0;
			double zrzlf = ToZRZLF(trzd, hb) * 0.01;
			gjtydzs = 1836 * zrzlf * 1 * 2 * lyxs * 0.5778 + 116.67;
		}

		private static int ToGJLYDB(double gjlydzs){
			int gjtydb=0;
			var rubyEngine = Ruby.CreateEngine();
			rubyEngine.ExecuteFile("GJLYDB.rb");
			dynamic ruby = rubyEngine.Runtime.Globals;
			dynamic config = ruby.GJLYDB.@new();
			gjlydzs = this.ToGJLYDZS();
			gjtydb = config.getGJLYDB(gjlydzs);
			return gjtydb;
		}

		private static double ToZRZLF(string trzd, string hb){
			double zrzlf = 75;
			double trzd_weight = 0.2;
			double hb_weight = 0.05;
			switch(trzd.Trim()) {
			case @"粉砂壤土\粘壤土":
				zrzlf += 90 * trzd_weight;
				break;
			case @"":
				zrzlf += 80 * trzd_weight;
				break;
			default:
				break;
			}
			switch(hb.Trim()) {
			case "80~100":
				zrzlf += 90 * hb_weight;
				break;

			default:
				break;
			}

			return zrzlf;

		}
	}
}

