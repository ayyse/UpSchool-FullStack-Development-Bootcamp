import {List, Button, Input, Header, Icon, Checkbox} from 'semantic-ui-react'
import {useState} from "react";
import './App.css'
import {TodoGetAllDto} from "./types/TodoTypes.ts";

const todoList: TodoGetAllDto[] = [
    {
        id: 1,
        task: "The UpSchool backend final project will be done. The Blazor part will be completed.",
        isCompleted: false,
        createdDate: new Date(2023,0,7)
    },
    {
        id: 2,
        task: "Shopping will be done.",
        isCompleted: true,
        createdDate: new Date(2023, 4,31)
    },
    {
        id: 3,
        task: "Finish book in two weeks.",
        isCompleted: false,
        createdDate: new Date(2023,11,20)
    },
    {
        id: 4,
        task: "Watch a movie.",
        isCompleted: false,
        createdDate: new Date(2023, 10,24)
    }
];
function App() {
    const [todos, setTodos] = useState<TodoGetAllDto[]>(todoList);

    const [newTodo, setNewTodo] = useState('');
    const addTodo = () => {
        if (newTodo.trim() !== '') {
            const newTodoItem: TodoGetAllDto = {
                id: todos.length + 1,
                task: newTodo,
                isCompleted: false,
                createdDate: new Date(),
            };
            setTodos([...todos, newTodoItem]);
            setNewTodo('');
        }
    };

    const deleteTodo = (id: number) => {
        const updatedTodos = todos.filter((todo) => todo.id !== id);
        setTodos(updatedTodos);
    };

    const sortTodosByDate = () => {
        const sortedTodos = [...todos].sort(
            (a, b) => a.createdDate.getTime() - b.createdDate.getTime()
        );
        setTodos(sortedTodos);
    };

    const toggleTodo = (id: number) => {
        const updatedTodos = todos.map((todo) => {
            if (todo.id === id) {
                return { ...todo, isCompleted: !todo.isCompleted };
            }
            return todo;
        });
        setTodos(updatedTodos);
    };

  return (
      <>
          <div style={{ marginBottom: '20px' }}>
              <Input value={newTodo} onChange={(e) => setNewTodo(e.target.value)} style={{ marginRight: '10px', width: 500 }} placeholder='Add task...' />
              <Button color='purple' onClick={addTodo} disabled={newTodo.trim() === ''}>Add</Button>
          </div>

          <Header as='h2' style={{ display: 'flex'}}>
              <Icon name='tasks' />
              <Header.Content>Todos</Header.Content>
              <Button style={{ marginLeft: 'auto' }} secondary onClick={sortTodosByDate}>
                  Sort by Date
              </Button>
          </Header>

          <List selection verticalAlign='middle'>
              {todos.map(todo => (
                  <List.Item style={{ display: 'flex'}}>
                      <div key={todo.id} onDoubleClick={() => toggleTodo(todo.id)} style={{ display: 'flex', textDecoration: todo.isCompleted ? 'line-through' : 'none' }}>
                          <Checkbox onClick={() => toggleTodo(todo.id)} checked={todo.isCompleted} style={{ marginRight: 20 }} />
                          <List.Content style={{ width: 100 }}>{todo.createdDate.toLocaleDateString()}</List.Content>
                          <List.Content className="truncate-text">{todo.task}</List.Content>
                      </div>
                      <List.Content style={{ marginLeft: 'auto' }}>
                          <Icon name='trash alternate outline' onClick={() => deleteTodo(todo.id)} />
                      </List.Content>
                  </List.Item>
              ))}
          </List>
      </>
  )
}

export default App
