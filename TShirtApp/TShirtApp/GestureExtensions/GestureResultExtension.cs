//using System;
//using System.Collections.Generic;
//using System.Reflection;
//using System.Text;
//using XLabs.Forms.Behaviors;

//namespace TShirtApp.GestureExtensions
//{
//    public static class GestureResultExtension
//    {
//        public static Double UbkHorizontalDistance(this GestureResult result)
//        {
//            Type t = result.GetType();
//            var f = t.GetField("HorizontalDistance");
//            double horizontalDistance = (double)f.GetValue(result);
//            return horizontalDistance;
//        }

//        public static Double UbkVerticalDistance(this GestureResult result)
//        {
//            Type t = result.GetType();
//            var f = t.GetField("VerticalDistance");
//            double verticalDistance = (double)f.GetValue(result);
//            return verticalDistance;
//        }
//    }
//}
