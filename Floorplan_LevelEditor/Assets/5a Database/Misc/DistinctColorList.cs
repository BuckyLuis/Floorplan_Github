using UnityEngine;
using System.Collections.Generic;

public class DistinctColorList  {

  
    public static List<Color> distinctColorsList = new List<Color>() {
        //36 colors  //http://graphicdesign.stackexchange.com/questions/3682/where-can-i-find-a-large-palette-set-of-contrasting-colors-for-coloring-many-d
        new Color(255,0,0),
        new Color(228,228,0), 
        new Color(0,255,0),
        new Color(0,255,255), 
        new Color(176,176,255),
        new Color(255,0,255), 
        new Color(228,228,228), 
        new Color(176,0,0),
        new Color(186,186,0), 
        new Color(0,176,0),
        new Color(0,176,176),
        new Color(132,132,255),
        new Color(176,0,176), 
        new Color(186,186,186), 
        new Color(135,0,0), 
        new Color(135,135,0), 
        new Color(0,135,0), 
        new Color(0,135,135),
        new Color(73,73,255),
        new Color(135,0,135), 
        new Color(135,135,135), 
        new Color(85,0,0),
        new Color(84,84,0), 
        new Color(0,85,0),
        new Color(0,85,85),
        new Color(0,0,255), 
        new Color(85,0,85),
        new Color(84,84,84)
    };
/*
    void Awake() {
        distinctColorsList = new List<Color>() {
            //36 colors  //http://graphicdesign.stackexchange.com/questions/3682/where-can-i-find-a-large-palette-set-of-contrasting-colors-for-coloring-many-d
            new Color(255,0,0),
            new Color(228,228,0), 
            new Color(0,255,0),
            new Color(0,255,255), 
            new Color(176,176,255),
            new Color(255,0,255), 
            new Color(228,228,228), 
            new Color(176,0,0),
            new Color(186,186,0), 
            new Color(0,176,0),
            new Color(0,176,176),
            new Color(132,132,255),
            new Color(176,0,176), 
            new Color(186,186,186), 
            new Color(135,0,0), 
            new Color(135,135,0), 
            new Color(0,135,0), 
            new Color(0,135,135),
            new Color(73,73,255),
            new Color(135,0,135), 
            new Color(135,135,135), 
            new Color(85,0,0),
            new Color(84,84,0), 
            new Color(0,85,0),
            new Color(0,85,85),
            new Color(0,0,255), 
            new Color(85,0,85),
            new Color(84,84,84)


                //64 colors
               /* new Color (1, 0, 103),
                new Color (213, 255, 0),
                new Color (255, 0, 86),
                new Color (158, 0, 142),
                14 76 161
                255 229 2
                0 95 57
                0 255 0
                149 0 58
                255 147 126
                164 36 0
                0 21 68
                145 208 203
                98 14 0
                107 104 130
                0 0 255
                0 125 181
                106 130 108
                0 174 126
                194 140 159
                190 153 112
                0 143 156
                95 173 78
                255 0 0
                255 0 246
                255 2 157
                104 61 59
                255 116 163
                150 138 232
                152 255 82
                167 87 64
                1 255 254
                255 238 232
                254 137 0
                189 198 255
                1 208 255
                187 136 0
                117 68 177
                165 255 210
                255 166 254
                119 77 0
                122 71 130
                38 52 0
                0 71 84
                67 0 44
                181 0 255
                255 177 103
                255 219 102
                144 251 146
                126 45 210
                189 211 147
                229 111 254
                222 255 116
                0 255 120
                0 155 255
                0 100 1
                0 118 255
                133 169 0
                0 185 23
                120 130 49
                0 255 198
                255 110 65
                232 94 190

        } ;
    }
*/
}



//http://godsnotwheregodsnot.blogspot.ru/2012/09/color-distribution-methodology.html
//http://graphicdesign.stackexchange.com/questions/3682/where-can-i-find-a-large-palette-set-of-contrasting-colors-for-coloring-many-d
//http://stackoverflow.com/questions/309149/generate-distinctly-different-rgb-colors-in-graphs
