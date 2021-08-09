import React from 'react';
import { Button, Card, Image } from 'semantic-ui-react';
import { Activity } from '../../../app/models/activity';

interface Props {
    // single activity of type Activity
    activity: Activity
    cancelSelectActivity: () => void;
    openForm: (id: string) => void
}

export default function ActivityDetails({ activity, cancelSelectActivity, openForm }: Props) {
    return (
        // fluid takes up all of available space inside the grid
        <Card fluid>
            <Image src={`/assets/categoryImages/${activity.category}.jpg`} wrapped ui={false} />
            <Card.Content>
                <Card.Header>{activity.title}</Card.Header>
                <Card.Meta>
                    <span className='date'>{activity.date}</span>
                </Card.Meta>
                <Card.Description>{activity.description}</Card.Description>
            </Card.Content>
            <Card.Content extra>
                <Button.Group widths='2'>
                    {/* use an empty arrow function so it doesn't render openForm until after the button is clicked */}
                    <Button onClick={() => openForm(activity.id)} basic color='blue' content='Edit' />
                    <Button onClick={cancelSelectActivity} basic color='grey' content='cancel' />
                </Button.Group>
            </Card.Content>
        </Card>
    )
}