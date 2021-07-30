using System;
using System.Collections.Generic;


namespace Chess{

public class RuleBook{

    private Location[,] board;
    private Move move;
    private Piece piece;
    public bool isCastle {get; set;}
    public bool castleCondition {get; set;}
    public bool isCheck {get; set;}
private  List<Move> moves = new List<Move>();
  public delegate int MoveDifference (Move move);
        MoveDifference mdSpacesUp = (Move move) => move.FromRow-move.ToRow;
        MoveDifference mdSpacesDown = (Move move) => move.ToRow - move.FromRow;
        MoveDifference mdSpacesLeft = (Move move) => move.ToCol - move.FromCol;
        MoveDifference mdSpacesRight = (Move move) => move.FromCol - move.ToCol;
        MoveDifference mdLeft = (Move move) => move.FromCol - move.ToCol;
        MoveDifference mdRight = (Move move) => move.ToCol - move.FromCol;
       
 public   delegate bool MoveDirection (Move move);
        MoveDirection mdUp = (Move move) => ((move.FromRow - move.ToRow) > 0) && (move.FromCol == move.ToCol);
        MoveDirection mdDown = (Move move) => ((move.FromRow - move.ToRow) < 0) && (move.FromCol == move.ToCol);
        MoveDirection mdDiag = (Move move) => (move.FromRow-move.ToRow)/(move.FromCol-move.ToCol) == 1 || (move.FromRow-move.ToRow)/(move.FromCol-move.ToCol) == -1;
       public  MoveDirection isLeftMove = (Move move) => ((move.FromCol - move.ToCol) > 0 && (move.FromRow == move.ToRow));
     public   MoveDirection isRightMove = (Move move) => ((move.FromCol - move.ToCol) < 0 && (move.FromRow == move.ToRow));
   
     
   public RuleBook(Move move, Location[,] board, List <Move> moves){
       this.board = board;
       this.move = move;
       piece = board[move.FromRow, move.FromCol].piece;
       this.moves = moves;
       isCheck = false;
   }


    private bool IsCheck(){
       

      

        return false;
    }
   public bool ScanBook(){
       

        if (!CheckColor()){
            if ((piece.type == Piece.PieceType.king) && (board[move.ToRow, move.ToCol].piece.type == Piece.PieceType.rook) && (piece.color == board[move.ToRow, move.ToCol].piece.color)){
                isCastle = true;
                Console.WriteLine(" RB.ISCASTLE "+ isCastle);
                if (CastleCondition()){
                    Console.WriteLine(" RB.CASTLECONDITION "+ castleCondition);
                    castleCondition = true;
                    return true;
                }
            }
            return false;
        }

        if (piece.type == Piece.PieceType.pawn){
            if (!PawnMove()){
                return false;
            }
        }

        if (piece.type == Piece.PieceType.rook){
            if (!RookMove()){
                return false;
            }
            
        }

        if (piece.type == Piece.PieceType.bishop){
            if (!BishopMove()){
                return false;
            }
            
        }

        if (piece.type == Piece.PieceType.queen){
            if (!QueenMove()){
                return false;
            }
            
        }
        
        if (piece.type == Piece.PieceType.knight){
            if (!KnightMove()){
                return false;
            }
        }
       
       if (piece.type == Piece.PieceType.king){
           
           if (!KingMove()){
               return false;
           }
       }
    return true;
   }
    

    public bool CastleCondition(){

        if (HorizontalCollisionCheck(piece.type)){
            if (piece.MoveCounter == 0){
                return true;
            }
        }

        return false;
    }
    private bool KingMove(){
        bool flag = false;
        
        if ((mdSpacesUp(move) == 1 || mdSpacesDown(move) == 1 || mdLeft(move) == 1 || mdRight(move) == 1)){
            flag = true;
        }

        try {
            if (mdDiag(move)){
                if (mdUp(move)){
                    if (move.FromRow - move.ToRow == 1){
                        flag = true;
                    }
                }
                else if (mdDown(move)){
                    if (move.FromRow - move.ToCol  == -1){
                        flag = true;
                    }
                }
                
             }
        }
        catch {}


       
        

        return flag;
    }




    //A knight's move is too complicated to be delegated. It would result in clutter and it is far clearer as a method in itself.
    private bool KnightMove(){
        bool flag = false;
        int fromRow = move.FromRow;
        int fromCol = move.FromCol;
        int toRow = move.ToRow;
        int toCol = move.ToCol;

        //To visualise the move, the following move index will be added to a comment above each if statement
        /* 
         D2R1 = down two right one
         D2L1 = down two left one
         U2L1 = up two left one
         U2R1 = up two right one
         R2U1 = right two up one
         R2D1 = right two down one
        
        */

        //  D2R1
        if ((fromRow + 2 == toRow) && (fromCol + 1 == toCol)){
            flag = true;
        }

        //  D2L1
        if ((fromRow + 2 == toRow) && (fromCol - 1 == toCol)){
            flag = true;
        }

        //  U2L1
        if ((fromRow -2 == toRow) && (fromCol - 1 == toCol)){
            flag = true;
        }

         //  U2R1
        if ((fromRow -2 == toRow) && (fromCol + 1 == toCol)){
            flag = true;
        }

        //  R2U1
        if ((fromRow - 1 == toRow) && (fromCol + 2 == toCol)){
            flag = true;
        }

        //  R2D1
        if ((fromRow + 1 == toRow) && (fromCol + 2 == toCol)){
            flag = true;
        }

        // L2U1
        if ((fromRow - 1 == toRow) && (fromCol - 2 == toCol)){
            flag = true;
        }

        // R2U1
        if ((fromRow + 1 == toRow) && (fromCol - 2 == toCol)){
            flag = true;
        }

       



        return flag;
    }
    private bool QueenMove(){
       

        if (mdDown(move) || mdUp(move)){
            return VerticalCollisionCheck(piece.type);
            
        }

        
        if (mdDiag(move)){
            return DiagonalCollisionCheck(piece.type);
        }

        if (isLeftMove(move) || isRightMove(move)){
            return HorizontalCollisionCheck(piece.type);
        }

       

        return false;
    }
    private bool RookMove(){
        
        if (mdUp(move) || mdDown(move)){
            return VerticalCollisionCheck(piece.type);
        }

        if (isLeftMove(move) || isRightMove(move)){
            return HorizontalCollisionCheck(piece.type);
        }

        

        return false;
    }

    private bool BishopMove(){

        //if a vertical move is passed, it will return a DivideByZeroException
         try {
            if (mdDiag(move)){
                return DiagonalCollisionCheck(piece.type);
            }
         }
         catch {}
        
        return false;
    }
    
   private bool PawnMove(){
        
        
        if (piece.color == Piece.Color.white){
            if (board[move.ToRow, move.ToCol].piece.color != Piece.Color.neutral && move.FromCol == move.ToCol){
                return false;
            }
            //if first move, can only move up to 2 spaces
            if (piece.MoveCounter == 0){
                if (((mdSpacesUp(move)==2 || mdSpacesUp(move)==1)) && mdSpacesLeft(move) == 0 && mdSpacesRight(move) == 0){
                    return VerticalCollisionCheck(piece.type);
                }
            }
        
            //can only advance 1 space when not first turn
            if (((mdSpacesUp(move)==1) &&(mdSpacesLeft(move) == 0) && (mdSpacesRight(move) == 0) && piece.MoveCounter != 0)){
                return VerticalCollisionCheck(piece.type);
            }
            
        

            //if changing columns. 
            //Going to use a flag here as the nesting of requirements is quite complex. 
            if (move.FromCol != move.ToCol){
                //if the from and to locations have different colours, and theyre only moving one space, it is allowed.
                if ((board[move.ToRow, move.ToCol].piece.color == Piece.Color.black) && (mdLeft(move) == 1 || mdRight(move) == 1)){
                   return true;    
                }
            }
            return false;
          }

        if (piece.color == Piece.Color.black){
            if (board[move.ToRow, move.ToCol].piece.color != Piece.Color.neutral && move.FromCol == move.ToCol){
                return false;
            }
            //if first move, can only move up to 2 spaces
            if (piece.MoveCounter == 0){
                if (((mdSpacesDown(move)==2 || mdSpacesDown(move)==1)) && mdSpacesLeft(move) == 0 && mdSpacesRight(move) == 0){
                    return VerticalCollisionCheck(piece.type);
                }
            }
        
            //can only advance 1 space when not first turn
            if (((mdSpacesDown(move)==1) &&(mdSpacesLeft(move) == 0) && (mdSpacesRight(move) == 0) && piece.MoveCounter != 0)){
                return VerticalCollisionCheck(piece.type);
            }
            
        

            //if changing columns. 
            //Going to use a flag here as the nesting of requirements is quite complex. 
            if (move.FromCol != move.ToCol){
                //if the from and to locations have different colours, and theyre only moving one space, it is allowed.
                if ((board[move.ToRow, move.ToCol].piece.color == Piece.Color.white) && (mdLeft(move) == 1 || mdRight(move) == 1)){
                   return true;    
                }
            }
            return false;
          }







    
      
      return false;
   }  
      
        
   private bool CheckColor(){
       if (board[move.FromRow, move.FromCol].piece.color == board[move.ToRow, move.ToCol].piece.color){
           return false;
       }
       return true;
   }
       
   

    public bool ScanUniqueMove(){
        string symbol = piece.Symbol;
        if (symbol.Contains("p")){
        
            if ((piece.color == Piece.Color.white && move.ToRow == 0)|| piece.color == Piece.Color.black && move.ToRow == 7){
                return true;
            }
               
        }
        return false;

    }

    public Piece GetUniquePiece(){
        string symbol = piece.Symbol;

        if (symbol.Contains("p")){
        
            if (piece.color == Piece.Color.white){
                return new Queen(Piece.Color.white);
            }
            else {
                return new Queen (Piece.Color.black);
            }
        }
        return null;
    }


    private bool DiagonalCollisionCheck(Piece.PieceType type){
    int fromRow = move.FromRow;
    int fromCol = move.FromCol;
    int toRow = move.ToRow;
    int toCol = move.ToCol;

    while (fromRow != toRow && fromCol != toCol){

        //if move is up NE, inc the location 
        if ((move.FromRow > move.ToRow) && (move.FromCol < move.ToCol)){
            fromRow--;
            fromCol++;
        }

        //if move is SE, inc the location
        if ((move.FromRow < move.ToRow && move.FromCol < move.ToCol) ){
            fromRow++;
            fromCol++;
        }


        //if move is NW, inc the location
        if (move.FromRow > move.ToRow && move.FromCol > move.ToCol){
            fromRow--;
            fromCol--;
        }

        //if move is SW, inc thhe location
        if (move.FromRow < move.ToRow && move.FromCol > move.ToCol){
            fromRow++;
            fromCol--;
        }
      
      
        try {
            //if the piece is not neutral, flag = false;
            if (board[fromRow, fromCol].piece.color != Piece.Color.neutral){
                if ((piece.color != board[toRow, toCol].piece.color) && (piece.color != Piece.Color.neutral) && (toRow == fromRow) && (toCol == fromCol)){
                    break;
                }
                return false;
            }
        }
        catch {
            break;
        }

           

    }


    return true;
}
   private bool VerticalCollisionCheck(Piece.PieceType type){
            bool flag = true;
            int fromRow = move.FromRow;
            int fromCol = move.FromCol;
            int toRow = move.ToRow;
            int toCol = move.ToCol;
          
            //looping through all the locations b/w the start location and end. 
            while (fromRow != toRow || fromCol != toCol){

                

                //if move is up board, inc the location 
                if (mdUp(move)){
                    fromRow--;
                }
                //if move is down board, inc the location
                else if (mdDown(move)){
                    fromRow ++;
                }


                try {
                    //if the piece is not neutral, flag = false;
                   if (board[fromRow, fromCol].piece.color != Piece.Color.neutral){
                       if ((piece.color != board[toRow, toCol].piece.color) && (piece.color != Piece.Color.neutral) && (toRow == fromRow) && (toCol == fromCol)){
                           flag = true;
                           break;
                       }
                        flag = false;
                    }
               }
               catch {
                   break;
               }

           }
        return flag;
        }

       

    private bool HorizontalCollisionCheck(Piece.PieceType type){
        int fromRow = move.FromRow;
        int fromCol = move.FromCol;
        int toRow = move.ToRow;
        int toCol = move.ToCol;
        
       
        //looping through all the locations b/w the start location and end. 
            while (fromRow != toRow || fromCol != toCol){

                

                //if move is up board, inc the location 
                if (isLeftMove(move)){
                    fromCol--;
                }
                //if move is down board, inc the location
                if (isRightMove(move)){
                    fromCol++;
                }

                try {
                    //if the piece is not neutral, flag = false;
                   if (board[fromRow, fromCol].piece.color != Piece.Color.neutral){
                       if (isCastle){
                           if (toCol == fromCol){
                                return true;
                            }
                       }
                        if ((piece.color != board[toRow, toCol].piece.color) && (piece.color != Piece.Color.neutral) && (toRow == fromRow) && (toCol == fromCol)){
                            break;
                        }
                    return false;

                    }
               }
               catch {
                   break;
               }
           }
           return true;
    }








}
}

