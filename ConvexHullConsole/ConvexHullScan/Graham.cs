using System;
using System.Collections.Generic;
using System.Linq;

namespace ConvexHull
{
  /// <summary>
  /// Graham Convex Hull from http://www.opita.net/node/755
  /// sometimes building non-convex hull
  /// </summary>
  public class Graham : IConvexHullScan
  {
    CPoint p0;
    int sizeP;
    int size;  // количество точек исходного множества

    // сортирует все точки множества в порядке возрастания 
    // полярного угла по отнощению к р0
    CPoint[] sort(CPoint[] P)
    {
      bool t = true;
      while (t)
      {
        t = false;
        for (int j = 0; j < sizeP - 1; j++)
          if (alpha(P[j]) > alpha(P[j + 1]))
          {
            CPoint tmp = P[j];
            P[j] = P[j + 1];
            P[j + 1] = tmp;
            t = true;
          }
          else
          if (alpha(P[j]) == alpha(P[j + 1]))
          {
            if (P[j].X > P[j + 1].X)
            {
              for (int k = j + 2; k < sizeP; k++)
                P[k - 1] = P[k];
              sizeP--;
              t = true;
            }
            else
                if (P[j + 1].X > P[j].X)
            {
              for (int k = j + 1; k < sizeP; k++)
                P[k - 1] = P[k];
              sizeP--;
              t = true;
            }
          }
      }
      return P;
    }

    // через векторное произведение определяет поворот
    //(если величина отрицательная - поворот против часовой стрелки, и наоборот)
    double angle(CPoint t0, CPoint t1, CPoint t2)
    {
      return (t1.X - t0.X) * (t2.Y - t0.Y) - (t2.X - t0.X) * (t1.Y - t0.Y);
    }

    // считает полярный угол данной точки по отнощению к р0
    double alpha(CPoint t)
    {
      t.X -= p0.X;
      t.Y = p0.Y - t.Y;
      double alph;
      if (t.X == 0) alph = Math.PI / 2;
      else
      {
        if (t.Y == 0) alph = 0;
        else alph = Math.Atan(Convert.ToDouble(t.Y) / Convert.ToDouble(t.X));
        if (t.X < 0) alph += Math.PI;
      }
      return alph;
    }

    // находим верхнюю левую точку
    CPoint GetTopPoint(List<CPoint> Q)
    {
      var p0 = Q[0];
      foreach (var p in Q)
      {
        if (p.Y < p0.Y) p0 = p;
      }
      return p0;
    }

    /// <summary>
    /// Convex hull scan with Graham method
    /// </summary>
    /// <param name="points">All points</param>
    /// <returns>Convex hull points</returns>
    /// <remarks>not used, becouse sometimes work not correct</remarks>
    public List<CPoint> ConvexHullScan(List<CPoint> points)
    {
      size = points.Count;

      //p0 - точка с минимальной координатой у или самая левая из таких точек при наличии совпадений
      p0 = GetTopPoint(points);
      int ind = 0;
      for (int i = 0; i < size; i++)
        if (points[i].Y > p0.Y) { p0 = points[i]; ind = i; }
        else
            if (points[i].Y == p0.Y && points[i].X < p0.X) { p0 = points[i]; ind = i; }

      //P остальные точки (все Q кроме р0) 
      sizeP = size - 1;
      CPoint[] P = new CPoint[sizeP];
      int j = 0;
      for (int i = 0; i < size; i++)
        if (i != ind)
        { P[j] = points[i]; j++; }

      P = sort(P);  //сортируем Р в порядке возрастания полярного угла,измеряемого 
                    //против часовой стрелки относительно р0

      var res = new List<CPoint>() { p0, P[0], P[1] };

      CPoint[] S = new CPoint[size]; //массив, который будет содержать вершины оболочки против часовой стрелки 
      S[0] = p0; S[1] = P[0]; S[2] = P[1];
      int last = 2;
      for (int i = 2; i < sizeP; i++)
      {
        while (last > 0 && angle(S[last - 1], S[last], P[i]) >= 0) last--;
        last++;
        S[last] = P[i];
      }

      //j = 1;
      //while (j < size && (S[j].X != 0 || S[j].Y != 0)) j++;
      //CPoint[] polygon = new CPoint[j];
      //for (int i = 0; i < j; i++) polygon[i] = S[i];

      return S.Where(x => x.X != 0 && x.Y != 0).ToList(); // it is not correct for 0:0 point
    }
  }
}
