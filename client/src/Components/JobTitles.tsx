import { FC, ReactNode } from "react";
import { List, Datagrid, TextField, ReferenceField } from "react-admin";

interface employeeProps {
    children?: ReactNode;
}

export const JobTitles: FC = (props) => {
    return (
        <List {...props} title="Cargos">
            <Datagrid rowClick="edit">
                <TextField source="id" />
                <ReferenceField
                    source="funcionario_Id"
                    reference="funcionarios"
                >
                    <TextField source="nome" />
                </ReferenceField>
                <TextField source="titulo" />
            </Datagrid>
        </List>
    );
};

