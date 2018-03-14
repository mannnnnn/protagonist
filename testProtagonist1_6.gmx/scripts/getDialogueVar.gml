///getDialogueVar(key/name, ?line)
var name = argument[0];
if (ds_map_exists(obj_dialogue.variables, name))
{
    return obj_dialogue.variables[? name];
}
else if (argument_count >= 2)
{
    var line = argument[1];
    show_error('Error in line "' + string(line) + '": The variable ' + string(name) + ' is not defined.', true);
}
else
{
    show_error('Error accessing variable: The variable ' + string(name) + ' is not defined.', true);
}