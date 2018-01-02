///evalTree(tree, str)
// recursively evaluates a the parseTree generated by parseToTree

var root = argument0;
var str = argument1;

switch (root[| OPERATOR_TYPE])
{
    case OP_PAREN:
        return evalTree(root[| OPERAND_A], str);
    case OP_NOT:
        return !evalTree(root[| OPERAND_A], str);
    case OP_AND:
        return evalTree(root[| OPERAND_A], str) && evalTree(root[| OPERAND_B], str);
    case OP_OR:
        return evalTree(root[| OPERAND_A], str) || evalTree(root[| OPERAND_B], str);
    case OP_EQ:
        return evalTree(root[| OPERAND_A], str) == evalTree(root[| OPERAND_B], str);
    case OP_GET:
        return stringToValue(root[| OPERAND_A], str);
}
