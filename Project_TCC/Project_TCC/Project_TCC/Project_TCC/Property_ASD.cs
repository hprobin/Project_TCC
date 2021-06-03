using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TCC
{
    class Property_ASD
    {                                          

        // ----   Woods(국산재)   ----
        public static double[] 낙엽송1 = { 12200, 8.0, 5.5, 9.0, 3.5, 1.25, 0.42, 560 };
        public static double[] 낙엽송2 = { 10800, 6.0, 4.0, 6.0, 3.5, 1.25, 0.42, 560 };
        public static double[] 낙엽송3 = { 9500, 3.5, 2.5, 3.5, 3.5, 1.25, 0.42, 560 };

        public static double[] 소나무1 = { 10300, 7.5, 5.0, 7.5, 3.0, 1.10, 0.37, 560 };
        public static double[] 소나무2 = { 9000, 6.0, 3.5, 4.5, 3.0, 1.10, 0.37, 560 };
        public static double[] 소나무3 = { 8300, 3.5, 2.0, 3.0, 3.0, 1.10, 0.37, 560 };

        public static double[] 잣나무1 = { 8500, 6.0, 5.0, 7.0, 2.5, 0.95, 0.32, 560 };
        public static double[] 잣나무2 = { 7500, 5.0, 3.5, 4.5, 2.5, 0.95, 0.32, 560 };
        public static double[] 잣나무3 = { 7000, 3.0, 2.0, 3.0, 2.5, 0.95, 0.32, 560 };

        public static double[] 삼나무1 = { 8000, 5.0, 4.0, 6.0, 2.5, 0.90, 0.30, 560 };
        public static double[] 삼나무2 = { 7000, 4.0, 2.5, 4.0, 2.5, 0.90, 0.30, 560 };
        public static double[] 삼나무3 = { 6000, 2.5, 1.5, 2.5, 2.5, 0.90, 0.30, 560 };

        public static double[] E6 = { 6000, 6.2, 2.4, 7.2, 2.0, 0.90, 0.30, 560 };
        public static double[] E6_실험 = { 6897, 7.5, 2.4, 10.6, 2.0, 0.90, 0.30, 560 };
        public static double[] E7 = { 7000, 7.2, 3.1, 8.5, 2.0, 0.90, 0.30, 560 };
        public static double[] E8 = { 8000, 8.2, 4.1, 9.6, 2.5, 1.00, 0.33, 560 };
        public static double[] E8_실험 = { 9802, 16.4, 4.1, 16.0, 2.5, 1.00, 0.33, 560 };
        public static double[] E9 = { 9000, 9.0, 5.5, 10.1, 2.5, 1.00, 0.33, 560 };
        public static double[] E10 = { 10000, 10.0, 6.0, 11.2, 3.0, 1.10, 0.37, 560 };
        public static double[] E10_실험 = { 10750, 16.3, 6.0, 16.5, 3.0, 1.10, 0.37, 560 };
        public static double[] E11 = { 11000, 11.3, 7.4, 11.7, 3.0, 1.10, 0.37, 560 };
        public static double[] E12 = { 12000, 12.4, 8.2, 12.0, 3.5, 1.20, 0.40, 560 };
        public static double[] E12_실험 = { 12531, 19.6, 8.2, 22.1, 3.5, 1.20, 0.40, 560 };
        public static double[] E13 = { 12000, 13.0, 9.4, 12.4, 3.5, 1.20, 0.40, 560 };
        public static double[] E14 = { 12000, 14.0, 10.7, 12.8, 3.5, 1.20, 0.40, 560 };
        public static double[] E15 = { 13000, 15.5, 12.0, 13.2, 3.5, 1.20, 0.40, 560 };
        public static double[] E16 = { 13000, 16.0, 13.0, 13.5, 3.5, 1.20, 0.40, 560 };
        public static double[] E17 = { 14000, 17.5, 14.1, 13.9, 4.0, 1.30, 0.43, 560 };

        // ----   Woods(외국산)   ----
        public static double[] C14 = { 7000, 6.7, 3.8, 8.4, 1.2, 0.73, 0.24, 560 };
        public static double[] C16 = { 8000, 7.6, 4.8, 8.9, 1.3, 0.78, 0.26, 560 };
        public static double[] C18 = { 9000, 8.6, 5.2, 9.5, 1.3, 0.83, 0.28, 560 };
        public static double[] C20 = { 9500, 9.5, 5.7, 10.0, 1.4, 0.88, 0.29, 560 };
        public static double[] C22 = { 10000, 10.5, 6.2, 10.5, 1.4, 0.93, 0.31, 560 };
        public static double[] C24 = { 11000, 11.4, 6.7, 11.1, 1.5, 0.98, 0.33, 560 };
        public static double[] C27 = { 11500, 12.9, 7.6, 11.6, 1.6, 0.98, 0.33, 560 };
        public static double[] C30 = { 12000, 14.3, 8.6, 12.1, 1.6, 0.98, 0.33, 560 };
        public static double[] C35 = { 13000, 16.7, 10.0, 13.2, 1.7, 0.98, 0.33, 560 };
        public static double[] C40 = { 14000, 19.0, 11.4, 13.7, 1.7, 0.98, 0.33, 560 };
        public static double[] C45 = { 15000, 21.4, 12.9, 14.2, 1.9, 0.98, 0.33, 560 };
        public static double[] C50 = { 16000, 23.8, 14.3, 15.3, 1.9, 0.98, 0.33, 560 };
        public static double[] D18 = { 9500, 8.6, 5.2, 9.5, 4.5, 0.83, 0.28, 560 };
        public static double[] D24 = { 10000, 11.4, 6.7, 11.1, 4.7, 0.98, 0.33, 560 };
        public static double[] D30 = { 11000, 14.3, 8.6, 12.1, 4.8, 0.98, 0.33, 560 };
        public static double[] D35 = { 12000, 16.7, 10.0, 13.2, 4.9, 0.98, 0.33, 560 };
        public static double[] D40 = { 13000, 19.0, 11.4, 13.7, 5.0, 0.98, 0.33, 560 };
        public static double[] D50 = { 14000, 23.8, 14.3, 15.3, 5.6, 0.98, 0.33, 560 };
        public static double[] D60 = { 17000, 28.6, 17.1, 16.8, 6.3, 1.10, 0.37, 560 };
        public static double[] D70 = { 20000, 33.3, 20.0, 17.9, 8.1, 1.22, 0.41, 560 };

        // ----   Concretes   ----
        public static double[] C_12_15 = { 27000, 0, 1.1, 12.0, 12.0, 0, 0, 560 };
        public static double[] C_16_20 = { 29000, 0, 1.3, 16.0, 16.0, 0, 0, 560 };
        public static double[] C_20_25 = { 30000, 0, 1.5, 20.0, 20.0, 0, 0, 560 };
        public static double[] C_25_30 = { 31000, 0, 1.8, 25.0, 25.0, 0, 0, 560 };
        public static double[] C_30_37 = { 33000, 0, 2.0, 30.0, 30.0, 0, 0, 560 };
        public static double[] C_35_45 = { 34000, 0, 2.2, 35.0, 35.0, 0, 0, 560 };
        public static double[] C_40_50 = { 35000, 0, 2.5, 40.0, 40.0, 0, 0, 560 };
        public static double[] C_45_55 = { 36000, 0, 2.7, 45.0, 45.0, 0, 0, 560 };
        public static double[] C_50_60 = { 37000, 0, 2.9, 50.0, 50.0, 0, 0, 560 };
        public static double[] C_55_67 = { 38000, 0, 3.0, 55.0, 55.0, 0, 0, 560 };
        public static double[] C_60_75 = { 39000, 0, 3.1, 60.0, 60.0, 0, 0, 560 };
        public static double[] C_70_85 = { 41000, 0, 3.2, 70.0, 70.0, 0, 0, 560 };
        public static double[] C_80_95 = { 42000, 0, 3.4, 80.0, 80.0, 0, 0, 560 };
        public static double[] C_90_105 = { 44000, 0, 3.5, 90.0, 90.0, 0, 0, 560 };

        // ----   Gluelam   ----
        public static double[] G_17S54B_4매이상 = { 14000, 18.0, 13.0, 15.0, 0.0, 0.0, 0.0, 560 };
        public static double[] G_15S46B_4매이상 = { 12000, 15.0, 11.0, 13.0, 0.0, 0.0, 0.0, 560 };
        public static double[] G_13S40B_4매이상 = { 11000, 13.0, 9.5, 11.0, 0.0, 0.0, 0.0, 560 };
        public static double[] G_12S37B_4매이상 = { 10000, 12.0, 8.5, 10.0, 0.0, 0.0, 0.0, 560 };
        public static double[] G_10S34B_4매이상 = { 9000, 11.0, 8.0, 9.5, 0.0, 0.0, 0.0, 560 };
        public static double[] G_9S31B_4매이상 = { 8000, 10.5, 7.5, 8.5, 0.0, 0.0, 0.0, 560 };
        public static double[] G_8S30B_4매이상 = { 7000, 10.0, 7.0, 8.0, 0.0, 0.0, 0.0, 560 };
        public static double[] G_7S27B_4매이상 = { 6000, 9.0, 6.5, 7.5, 0.0, 0.0, 0.0, 560 };
        public static double[] G_6S25B_4매이상 = { 5000, 8.5, 6.0, 7.0, 0.0, 0.0, 0.0, 560 };

        public static double[] G_17S49B_3매 = { 14000, 16.0, 13.0, 14.0, 0.0, 0.0, 0.0, 560 };
        public static double[] G_15S43B_3매 = { 12000, 14.0, 11.0, 12.0, 0.0, 0.0, 0.0, 560 };
        public static double[] G_13S37B_3매 = { 11000, 12.0, 9.5, 10.0, 0.0, 0.0, 0.0, 560 };
        public static double[] G_12S33B_3매 = { 10000, 11.0, 8.5, 9.0, 0.0, 0.0, 0.0, 560 };
        public static double[] G_10S30B_3매 = { 9000, 10.0, 8.0, 8.5, 0.0, 0.0, 0.0, 560 };
        public static double[] G_9S28B_3매 = { 8000, 9.5, 7.5, 8.0, 0.0, 0.0, 0.0, 560 };
        public static double[] G_8S27B_3매 = { 7000, 9.0, 7.0, 7.5, 0.0, 0.0, 0.0, 560 };
        public static double[] G_7S25B_3매 = { 6000, 8.5, 6.5, 6.5, 0.0, 0.0, 0.0, 560 };
        public static double[] G_6S24B_3매 = { 5000, 8.0, 6.0, 6.0, 0.0, 0.0, 0.0, 560 };

        public static double[] G_17S45B_2매 = { 14000, 15.0, 13.0, 14.0, 0.0, 0.0, 0.0, 560 };
        public static double[] G_15S39B_2매 = { 12000, 13.0, 11.0, 12.0, 0.0, 0.0, 0.0, 560 };
        public static double[] G_13S34B_2매 = { 11000, 11.0, 9.5, 10.0, 0.0, 0.0, 0.0, 560 };
        public static double[] G_12S30B_2매 = { 10000, 10.0, 8.5, 9.0, 0.0, 0.0, 0.0, 560 };
        public static double[] G_10S28B_2매 = { 9000, 9.5, 8.0, 8.5, 0.0, 0.0, 0.0, 560 };
        public static double[] G_9S27B_2매 = { 8000, 9.0, 7.5, 8.0, 0.0, 0.0, 0.0, 560 };
        public static double[] G_8S25B_2매 = { 7000, 8.5, 7.0, 7.5, 0.0, 0.0, 0.0, 560 };
        public static double[] G_7S24B_2매 = { 6000, 8.0, 6.5, 6.5, 0.0, 0.0, 0.0, 560 };
        public static double[] G_6S22B_2매 = { 5000, 7.5, 6.0, 6.0, 0.0, 0.0, 0.0, 560 };

        public static double[] G_17S49B_대칭 = { 14000, 16.0, 11.0, 12.0, 0.0, 0.0, 0.0, 560 };
        public static double[] G_15S43B_대칭 = { 12000, 14.0, 9.0, 11.0, 0.0, 0.0, 0.0, 560 };
        public static double[] G_13S37B_대칭 = { 11000, 12.0, 8.0, 10.0, 0.0, 0.0, 0.0, 560 };
        public static double[] G_12S33B_대칭 = { 10000, 11.0, 7.0, 8.0, 0.0, 0.0, 0.0, 560 };
        public static double[] G_10S30B_대칭 = { 9000, 10.0, 6.5, 7.5, 0.0, 0.0, 0.0, 560 };
        public static double[] G_9S27B_대칭 = { 8000, 9.0, 6.0, 7.0, 0.0, 0.0, 0.0, 560 };
        public static double[] G_8S25B_대칭 = { 7000, 8.0, 5.5, 6.5, 0.0, 0.0, 0.0, 560 };
        public static double[] G_7S24B_대칭 = { 6000, 7.0, 5.0, 6.0, 0.0, 0.0, 0.0, 560 };
        public static double[] G_6S22B_대칭 = { 5000, 3.0, 4.0, 5.5, 0.0, 0.0, 0.0, 560 };

        public static double[] G_16S48B_비대칭 = { 13000, 16.0, 10.0, 12.0, 0.0, 0.0, 0.0, 560 };
        public static double[] G_14S42B_비대칭 = { 11000, 14.0, 9.0, 10.0, 0.0, 0.0, 0.0, 560 };
        public static double[] G_12S36B_비대칭 = { 10000, 12.0, 8.0, 9.5, 0.0, 0.0, 0.0, 560 };
        public static double[] G_11S31B_비대칭 = { 9000, 10.0, 7.0, 8.0, 0.0, 0.0, 0.0, 560 };
        public static double[] G_10S28B_비대칭 = { 8000, 9.5, 6.0, 7.5, 0.0, 0.0, 0.0, 560 };
        public static double[] G_9S25B_비대칭 = { 7000, 8.5, 6.0, 7.0, 0.0, 0.0, 0.0, 560 };
        public static double[] G_8S24B_비대칭 = { 6500, 8.0, 5.0, 6.0, 0.0, 0.0, 0.0, 560 };
        public static double[] G_7S22B_비대칭 = { 6000, 7.5, 4.5, 5.5, 0.0, 0.0, 0.0, 560 };
        public static double[] G_6S21B_비대칭 = { 5000, 7.0, 4.5, 5.0, 0.0, 0.0, 0.0, 560 };
    }
}

