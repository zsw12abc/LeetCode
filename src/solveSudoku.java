public class solveSudoku {
    /**
     * Write a program to solve a Sudoku puzzle by filling the empty cells.
     * Empty cells are indicated by the character '.'.
     * You may assume that there will be only one unique solution.
     *
     * @param board
     */
    public void solveSudoku(char[][] board) {
        if (board == null || board.length == 0) {
            return;
        }
        solve(board);
    }

    /**
     * @param board
     * @return true or false
     */
    public boolean solve(char[][] board) {
        for (int i = 0; i < board.length; i++) {
            for (int j = 0; j < board[0].length; j++) {
                if (board[i][j] == '.') {
                    for (char c = '1'; c <= '9'; c++) {
                        if (isValid(board, i, j, c)) {
                            board[i][j] = c; //put c for this cell
                            if (solve(board)) {
                                return true; //if it's the solution reture true
                            } else {
                                board[i][j] = '.'; //otherwise go back
                            }
                        }
                    }
                    return false;
                }
            }
        }
        return true;
    }

    /**
     * @param board
     * @param row
     * @param col
     * @param c
     * @return true or false
     */
    private boolean isValid(char[][] board, int row, int col, char c) {
        for (int i = 0; i < 9; i++) {
            if (board[i][col] != '.' && board[i][col] == c) return false;
            if (board[row][i] != '.' && board[row][i] == c) return false;
            if (board[3 * (row / 3) + i / 3][3 * (col / 3) + i % 3] == c) return false;
        }
        return true;
    }
}
