import React, {Component} from 'react';
import TodoItem from "./TodoItem";
import PropTypes from "prop-types"

export default class Todos extends Component {
    static displayName = Todos.name;



    render() {
        return this.props.todos.map((todo) =>
            (<TodoItem key={todo.id}
                       todo={todo}
                       markComplete={this.props.markComplete}
                       deleteTodo = {this.props.deleteTodo}
            />));
    }
}

//PropTypes
Todos.propTypes = {
    todos: PropTypes.array.isRequired,
    markComplete: PropTypes.func.isRequired,
    deleteTodo: PropTypes.func.isRequired,
}
