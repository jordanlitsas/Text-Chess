using System;
using System.Collections.Generic;
namespace Chess{

public static class CheckMater{
    public enum color{
        white,
        black,
        temp
    }




    




    //When a player makes a move, this method is called to return the enemy piece that is threatening your king.
    public static Piece Run(Board b, Piece.Color playerColor){
        Board board = b;
        Piece threateningPiece = null;
        color color = color.temp;

        if (playerColor == Piece.Color.white){
            color = color.white;
        }
        else if (playerColor == Piece.Color.black){
            color = color.black;
        }

        int row=0; 
        int col=0;

        int rowlength = b.locations.GetLength(0);
        int colLength = b.locations.GetLength(1);

        for (int i = 0; i < rowlength; i++){
            for (int j = 0; j < colLength; j++){
                //find location of king
                if (color == color.white){
                    if (b.locations[i, j].piece.type == Piece.PieceType.king && b.locations[i, j].piece.color == Piece.Color.white){
                        row = i;
                        col = j;
                    }
                }
                else if (color == color.black){
                    if (b.locations[i, j].piece.type == Piece.PieceType.king && b.locations[i, j].piece.color == Piece.Color.black){
                        row = i;
                        col = j;
                    }
                }
                
                
            }
        }

        if (HorizontalCheck(row, col, b, color) != null){
            threateningPiece = HorizontalCheck(row, col, b, color);

        }

        if (VerticalCheck(row, col, b, color) != null){
            threateningPiece = VerticalCheck(row, col, b, color);

        }


        
        if (DiagonalCheck(row, col, b, color) != null){
            threateningPiece = DiagonalCheck(row, col, b, color);

        }
        
        if (KnightCheck(row, col, b, color) != null){
            threateningPiece = KnightCheck(row, col, b, color);
        }

        if (threateningPiece == null){
            return null;
        }

         return threateningPiece;
        }

    
    private static Piece KnightCheck(int i, int j, Board board, color c){
            int row = i;
            int col = j;
            Board b = board;
            Piece threateningPiece = null; 
            //list to store enemy pieces
            try {
                if (c == color.white){

                    if (b.locations[i+2, j+1].piece.type == Piece.PieceType.knight && b.locations[row+2, col+1].piece.color == Piece.Color.black){
                        threateningPiece = b.locations[row+2, col+1].piece;
                    }

                    if (b.locations[i+2, j-1].piece.type == Piece.PieceType.knight && b.locations[i+2, j-1].piece.color == Piece.Color.black){
                        threateningPiece = b.locations[i+2, j-1].piece;
                    }

                        if (b.locations[i-2, j-1].piece.type == Piece.PieceType.knight && b.locations[i-2, j-1].piece.color == Piece.Color.black){
                        threateningPiece = b.locations[i-2, j-1].piece;
                    }

                        if (b.locations[i-2, j+1].piece.type == Piece.PieceType.knight && b.locations[i-2, j+1].piece.color == Piece.Color.black){
                        threateningPiece = b.locations[i-2, j+1].piece;
                    }

                        if (b.locations[i-1, j+2].piece.type == Piece.PieceType.knight && b.locations[i-1, j+2].piece.color == Piece.Color.black){
                        threateningPiece = b.locations[i-1, j+2].piece;
                    }

                        if (b.locations[i+1, j+2].piece.type == Piece.PieceType.knight && b.locations[i+1, j+2].piece.color == Piece.Color.black){
                        threateningPiece = b.locations[i+1, j+2].piece;
                    }

                        if (b.locations[i-1, j-2].piece.type == Piece.PieceType.knight && b.locations[i-1, j-2].piece.color == Piece.Color.black){
                        threateningPiece = b.locations[i-2, j-2].piece;
                    }

                        if (b.locations[i+1, j-2].piece.type == Piece.PieceType.knight && b.locations[i+1, j-2].piece.color == Piece.Color.black){
                        threateningPiece = b.locations[i+1, j-2].piece;
                    }
                }

                if (c == color.black){

                  
                
                    if (b.locations[i+2, j-1].piece.type == Piece.PieceType.knight && b.locations[i+2, j-1].piece.color == Piece.Color.white){
                        threateningPiece = b.locations[i+2, j-1].piece;
                    }
                        if (b.locations[i+2, j+1].piece.type == Piece.PieceType.knight && b.locations[i+2, j+1].piece.color == Piece.Color.white){
                            threateningPiece = b.locations[i+2, j+1].piece;
                        }
                    if(b.locations[i-2, j-1].piece.type == Piece.PieceType.knight && b.locations[i-2, j-1].piece.color == Piece.Color.white){
                        threateningPiece = b.locations[i-2, j-1].piece;
                    }

                        if (b.locations[i-2, j+1].piece.type == Piece.PieceType.knight && b.locations[i-2, j+1].piece.color == Piece.Color.white){
                        threateningPiece = b.locations[i-2, j+1].piece;
                    }

                        if (b.locations[i-1, j+2].piece.type == Piece.PieceType.knight && b.locations[i-1, j+2].piece.color == Piece.Color.white){
                        threateningPiece = b.locations[i-1, j+2].piece;
                    }

                        if (b.locations[i+1, j+2].piece.type == Piece.PieceType.knight && b.locations[i+1, j+2].piece.color == Piece.Color.white){
                        threateningPiece = b.locations[i+1, j+2].piece;
                    }

                        if (b.locations[i-1, j-2].piece.type == Piece.PieceType.knight && b.locations[i-1, j-2].piece.color == Piece.Color.white){
                        threateningPiece = b.locations[i-2, j-2].piece;
                    }

                        if (b.locations[i+1, j-2].piece.type == Piece.PieceType.knight && b.locations[i+1, j-2].piece.color == Piece.Color.white){
                        threateningPiece = b.locations[i+1, j-2].piece;
                    }
                }
               
 

            }
            catch{}
                          

                    
            
            
            

            return threateningPiece;
    }



    private static Piece DiagonalCheck(int i, int j, Board board, color c){
            Piece threateningPiece = null;
            
                if (NE(i, j, board, c) != null){
                    threateningPiece = NE(i, j, board, c);
                }

                if (SE(i, j, board, c) != null){
                    threateningPiece = SE(i, j, board, c);
                }

                if (NW(i, j, board, c) != null){
                    threateningPiece = NW(i, j, board, c);
                }

                if (SW(i, j, board, c) != null){
                    threateningPiece = SW(i, j, board, c);
                }
          


            return threateningPiece;
        }
    private static Piece SW(int i, int j, Board board, color c){
            int row = i+1;
            int col = j-1;
            Board b = board;
            Piece threateningPiece = null; 
            //list to store enemy pieces
            List<Piece> SWLine = new List<Piece>();

            //line of pieces left of king
            while (row <= 7 && col >= 0){
                //make sure piece is not empty
                if (b.locations[row, col].piece.type != Piece.PieceType.empty){
                    SWLine.Add(b.locations[row, col].piece);
                }
                row++;
                col--;
            
            }

          
            
            if (c == color.white){
                try {

                if (SWLine[0].color == Piece.Color.black && (SWLine[0].type == Piece.PieceType.king) && SWLine[0].Equals(board.locations[i+1, j-1].piece)){
                     threateningPiece = SWLine[0];
                }
                if ((SWLine[0].type == Piece.PieceType.queen || SWLine[0].type == Piece.PieceType.bishop) && SWLine[0].color == Piece.Color.black){
                    threateningPiece = SWLine[0];
                }      
            }
            catch{}
            }

            if (c == color.black){
                try {

                if ((SWLine[0].color == Piece.Color.white && (SWLine[0].type == Piece.PieceType.king) && SWLine[0].Equals(board.locations[i+1, j-1].piece)) || (SWLine[0].color == Piece.Color.white && (SWLine[0].type == Piece.PieceType.pawn) && SWLine[0].Equals(board.locations[i+1, j-1].piece))){
                     threateningPiece = SWLine[0];
                }
                if ((SWLine[0].type == Piece.PieceType.queen || SWLine[0].type == Piece.PieceType.bishop) && SWLine[0].color == Piece.Color.white){
                    threateningPiece = SWLine[0];
                }      
            }
            catch{}
            }
                


            return threateningPiece;
        }
    private static Piece NW(int i, int j, Board board, color c){
            int row = i-1;
            int col = j-1;
            Board b = board;
            Piece threateningPiece = null; 
            //list to store enemy pieces
            List<Piece> NWLine = new List<Piece>();

            //line of pieces left of king
            while (row >= 0 && col >= 0){
                //make sure piece is not empty
                if (b.locations[row, col].piece.type != Piece.PieceType.empty){
                    NWLine.Add(b.locations[row, col].piece);
                }
                row--;
                col--;
            
            }
            
            if (c == color.white){
            try {

                if (((NWLine[0].type == Piece.PieceType.pawn) && NWLine[0].Equals(board.locations[i-1, j-1].piece) && NWLine[0].color == Piece.Color.black) || (NWLine[0].type == Piece.PieceType.king) && NWLine[0].Equals(board.locations[i-1, j-1].piece)){
                     threateningPiece = NWLine[0];
                }
                if ((NWLine[0].type == Piece.PieceType.queen || NWLine[0].type == Piece.PieceType.bishop) && NWLine[0].color == Piece.Color.black){
                    threateningPiece = NWLine[0];
                }      
            }
            catch{}  
            }

            if (c == color.black){
                try {

                if ((NWLine[0].color == Piece.Color.white) && (NWLine[0].type == Piece.PieceType.king) && NWLine[0].Equals(board.locations[i-1, j-1].piece)){
                     threateningPiece = NWLine[0];
                }
                if ((NWLine[0].type == Piece.PieceType.queen || NWLine[0].type == Piece.PieceType.bishop) && NWLine[0].color == Piece.Color.white){
                    threateningPiece = NWLine[0];
                }      
            }
            catch{}
            }
              

       
            return threateningPiece;
        }
    private static Piece SE(int i, int j, Board board, color c){
            int row = i+1;
            int col = j+1;
            Board b = board;
            Piece threateningPiece = null; 
            //list to store enemy pieces
            List<Piece> SELine = new List<Piece>();

            //line of pieces left of king
            while (row <= 7 && col <= 7){
                //make sure piece is not empty
                if (b.locations[row, col].piece.type != Piece.PieceType.empty){
                    SELine.Add(b.locations[row, col].piece);
                }
                row++;
                col++;
            
            }
            
            if (c == color.white){
            //if the closest non empty spot on the board is a black queen or rook, the king is in check.
            try {

                if ((SELine[0].type == Piece.PieceType.king) && SELine[0].Equals(board.locations[i+1, j+1].piece)){
                     threateningPiece = SELine[0];
                }
                if ((SELine[0].type == Piece.PieceType.queen || SELine[0].type == Piece.PieceType.bishop) && SELine[0].color == Piece.Color.black){
                    threateningPiece = SELine[0];
                }      
            }
            catch{} 
            }

            if (c == color.black){
                try {

                    if (((SELine[0].type == Piece.PieceType.king) && SELine[0].Equals(board.locations[i+1, j+1].piece) && SELine[0].color == Piece.Color.white) ||((SELine[0].type == Piece.PieceType.pawn) && SELine[0].Equals(board.locations[i+1, j+1].piece) && SELine[0].color == Piece.Color.white) ){
                        threateningPiece = SELine[0];
                    }
                    if ((SELine[0].type == Piece.PieceType.queen || SELine[0].type == Piece.PieceType.bishop) && SELine[0].color == Piece.Color.white){
                        threateningPiece = SELine[0];
                    }      
            }
            catch{} 
            }
              

            return threateningPiece;
        }
    private static Piece NE(int i, int j, Board board, color c){
            int row = i-1;
            int col = j+1;
            Board b = board;
            Piece threateningPiece = null; 
            //list to store enemy pieces
            List<Piece> NELine = new List<Piece>();

            //line of pieces left of king
            while (row >= 0 && col <= 7){
                //make sure piece is not empty
                if (b.locations[row, col].piece.type != Piece.PieceType.empty){
                    NELine.Add(b.locations[row, col].piece);
                }
                row--;
                col++;
            
            }
            
            if (c == color.white){
            //if the closest non empty spot on the board is a black queen or rook, the king is in check.
                try {

                    if (((NELine[0].type == Piece.PieceType.pawn && NELine[0].Equals(board.locations[i-1, j+1].piece)) && NELine[0].color == Piece.Color.black) ||((NELine[0].color == Piece.Color.black) && (NELine[0].type == Piece.PieceType.king) && NELine[0].Equals(board.locations[i-1, j+1].piece))){
                        threateningPiece = NELine[0];
                    }
                    if ((NELine[0].type == Piece.PieceType.queen || NELine[0].type == Piece.PieceType.bishop) && NELine[0].color == Piece.Color.black){
                        threateningPiece = NELine[0];
                    }      
                }
                catch{}  
            }
            
            if (c == color.black){
                try {

                    if ((NELine[0].color == Piece.Color.white) && (NELine[0].type == Piece.PieceType.king) && NELine[0].Equals(board.locations[i-1, j+1].piece)){
                        threateningPiece = NELine[0];
                    }
                    if ((NELine[0].type == Piece.PieceType.queen || NELine[0].type == Piece.PieceType.bishop) && NELine[0].color == Piece.Color.white){
                        threateningPiece = NELine[0];
                    }      
                }
                catch{}  
            }
            
              

       
            return threateningPiece;
        }
        






    private static Piece HorizontalCheck(int i, int j, Board board, color c){
            Piece threateningPiece = null; 
            if (East(i, j, board, c) != null){
                threateningPiece = East(i, j, board, c);
            }
            if (West(i, j, board, c) != null){
                threateningPiece = West(i, j, board, c);
            }   
            return threateningPiece;
        }
    private static Piece West (int i, int j, Board board, color c){
            int row = i;
            int leftLine = j-1;
            Board b = board;
            Piece threateningPiece = null; 
            //list to store enemy pieces
            List<Piece> horizontalLeft = new List<Piece>();

            //line of pieces left of king
            while (leftLine >= 0){
                //make sure piece is not empty
                if (b.locations[row, leftLine].piece.type != Piece.PieceType.empty){
                    horizontalLeft.Add(b.locations[row, leftLine].piece);
                }
                leftLine--;
            
            }
            
            if (c == color.white){
                try {
                    if ((horizontalLeft[0].type == Piece.PieceType.king) && (horizontalLeft[0].Equals(board.locations[i, j-1].piece) && horizontalLeft[0].color == Piece.Color.black)){
                        threateningPiece = horizontalLeft[0];
                    }
                    if ((horizontalLeft[0].type == Piece.PieceType.queen || horizontalLeft[0].type == Piece.PieceType.rook) && horizontalLeft[0].color == Piece.Color.black){
                        threateningPiece = horizontalLeft[0];
                }      
            }
            catch{}
            }

            if (c == color.black){
                try {
                    if ((horizontalLeft[0].type == Piece.PieceType.king) && (horizontalLeft[0].Equals(board.locations[i, j-1].piece) && horizontalLeft[0].color == Piece.Color.white)){
                        threateningPiece = horizontalLeft[0];
                    }
                    if ((horizontalLeft[0].type == Piece.PieceType.queen || horizontalLeft[0].type == Piece.PieceType.rook) && horizontalLeft[0].color == Piece.Color.white){
                        threateningPiece = horizontalLeft[0];
                }      
            }
            catch{}
            }
                

       
            return threateningPiece;
        }
    private static Piece East(int i, int j, Board board, color c){
            int row = i;
            int rightLine = j+1;
            Board b = board;
            Piece threateningPiece = null; 
            //list to store enemy pieces
            List<Piece> horizontalRight = new List<Piece>();

            //line of pieces right of king
            while (rightLine <= 7){
                //make sure piece is not empty
                if (b.locations[row, rightLine].piece.type != Piece.PieceType.empty){
                    horizontalRight.Add(b.locations[row, rightLine].piece);
                }
                rightLine++;
            
            }
            
            if (c == color.white){
                try {
                    if ((horizontalRight[0].type == Piece.PieceType.king) && (horizontalRight[0].Equals(board.locations[i, j+1].piece) && horizontalRight[0].color == Piece.Color.black)){
                        threateningPiece = horizontalRight[0];
                    }
                    if ((horizontalRight[0].type == Piece.PieceType.queen || horizontalRight[0].type == Piece.PieceType.rook) && horizontalRight[0].color == Piece.Color.black){
                        threateningPiece = horizontalRight[0];
                }      
            }
            catch{}
            }

            if (c == color.black){
                try {
                    if ((horizontalRight[0].type == Piece.PieceType.king) && (horizontalRight[0].Equals(board.locations[i, j+1].piece) && horizontalRight[0].color == Piece.Color.white)){
                        threateningPiece = horizontalRight[0];
                    }
                    if ((horizontalRight[0].type == Piece.PieceType.queen || horizontalRight[0].type == Piece.PieceType.rook) && horizontalRight[0].color == Piece.Color.white){
                        threateningPiece = horizontalRight[0];
                }      
            }
            catch{}
            }
                

       
            return threateningPiece;
        }







    private static Piece VerticalCheck(int i, int j, Board board, color c){
            Piece threateningPiece = null;
             if (North(i, j, board, c) != null){
                threateningPiece = North(i, j, board, c);
            } 
            if (South(i, j, board, c) != null){
                threateningPiece = South(i, j, board, c);
            }
            
            return threateningPiece;
        }

    private static Piece South(int i, int j, Board board, color c){
            int downLine = i+1;
            int col = j;
            Board b = board;
            Piece threateningPiece = null; 
            //list to store enemy pieces
            List<Piece> VerticalDown = new List<Piece>();

            //line of pieces left of king
            while (downLine <= 7){
                //make sure piece is not empty
                if (b.locations[downLine, col].piece.type != Piece.PieceType.empty){
                    VerticalDown.Add(b.locations[downLine, col].piece);
                }
                downLine++;
            
            }
            
            if (c == color.white){
                try {
                if ((VerticalDown[0].type == Piece.PieceType.king) && (VerticalDown[0].Equals(board.locations[i+1, j].piece))&& VerticalDown[0].color == Piece.Color.black){
                     threateningPiece = VerticalDown[0];
                }
                if ((VerticalDown[0].type == Piece.PieceType.queen || VerticalDown[0].type == Piece.PieceType.rook) && VerticalDown[0].color == Piece.Color.black){
                    threateningPiece = VerticalDown[0];
                }      
            }
            catch{}
            }

            if (c == color.black){
                try {
                if ((VerticalDown[0].type == Piece.PieceType.king) && (VerticalDown[0].Equals(board.locations[i+1, j].piece))&& VerticalDown[0].color == Piece.Color.white){
                     threateningPiece = VerticalDown[0];
                }
                if ((VerticalDown[0].type == Piece.PieceType.queen || VerticalDown[0].type == Piece.PieceType.rook) && VerticalDown[0].color == Piece.Color.white){
                    threateningPiece = VerticalDown[0];
                }      
            }
            catch{}
            }
                

       
            return threateningPiece;
        }
    private static Piece North(int i, int j, Board board, color c){
            int upLine = i-1;
            int col = j;
            Board b = board;
            Piece threateningPiece = null; 
            //list to store enemy pieces
            List<Piece> VerticalUp = new List<Piece>();

            //line of pieces left of king
            while (upLine >= 0){
                //make sure piece is not empty
                if (b.locations[upLine, col].piece.type != Piece.PieceType.empty){
                    VerticalUp.Add(b.locations[upLine, col].piece);

                }
                upLine--;
            
            }
            
            if (c == color.white){
                try {
                    if ((VerticalUp[0].type == Piece.PieceType.king) && (VerticalUp[0].Equals(board.locations[i-1, j].piece) && VerticalUp[0].color == Piece.Color.black)){
                        threateningPiece = VerticalUp[0];
                    }
                    if ((VerticalUp[0].type == Piece.PieceType.queen || VerticalUp[0].type == Piece.PieceType.rook) && VerticalUp[0].color == Piece.Color.black){
                        threateningPiece = VerticalUp[0];
                    }      
                }
                catch{}
            }       

            if (c == color.black){
                try {
                    if ((VerticalUp[0].type == Piece.PieceType.king) && (VerticalUp[0].Equals(board.locations[i-1, j].piece) && VerticalUp[0].color == Piece.Color.white)){
                        threateningPiece = VerticalUp[0];
                    }
                    if ((VerticalUp[0].type == Piece.PieceType.queen || VerticalUp[0].type == Piece.PieceType.rook) && VerticalUp[0].color == Piece.Color.white){
                        threateningPiece = VerticalUp[0];
                    }      
                }
                catch{}
            }         

       
            return threateningPiece;
        }

}
}


   
  