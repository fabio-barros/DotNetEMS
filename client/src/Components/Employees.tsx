import React, { ReactElement, FC, ReactNode, useState, useEffect } from "react";
import {
    List,
    Datagrid,
    TextField,
    ListProps,
    EditButton,
    Edit,
    SimpleForm,
    TextInput,
    DateInput,
    Create,
    useDataProvider,
    Record,
    SingleFieldList,
    ChipField,
    ArrayField,
    DateField,
    NumberField
} from "react-admin";

interface employeeProps {
    children?: ReactNode;
}

interface Cargos {
    id: number;
    inicio: Date;
    titulo: string;
}

interface Employee {
    id: number;
    nome: string;
    sobrenome: string;
    cpf: string;
    genero: string;
    dataNascimento: Date;
    dataContratacao: Date;
    cargos?: Array<Cargos>;
}

export const EmployeeIcon: FC = () => (
    <span
        className="iconify"
        data-icon="mdi:badge-account-horizontal"
        data-inline="false"
        data-width="30"
        data-height="30"
    ></span>
);

// export const EmployeeList: FC = (props) => {
//     return (
//         <List {...props} title="Funcionários">
//             <Datagrid rowClick="edit">
//                 <TextField source="id"></TextField>
//                 <TextField source="nome"></TextField>
//                 <TextField source="sobrenome"></TextField>
//                 <TextField source="cpf"></TextField>
//                 <TextField source="genero"></TextField>
//                 <DateField source="dataNascimento"></DateField>
//                 <DateField  source="dataContratacao" ></DateField>
//                 <EditButton basePath="/funcionarios" />
//                 <ArrayField source="cargos">
//                     <SingleFieldList>
//                         <ChipField source="titulo"  />
//                     </SingleFieldList>
//                 </ArrayField>
//             </Datagrid>
//         </List>
//     );
// };

export const EmployeeList: FC = (props) => {
    return (
        <List {...props}>
            <Datagrid rowClick="edit">
                <TextField source="id" />
                <NumberField source="funcionarioNumero" />
                <TextField source="nome" />
                <TextField source="sobrenome" />
                <TextField source="cpf" />
                <DateField source="dataNascimento" />
                <TextField source="genero" />
                <DateField source="dataContratacao" />
                <ArrayField source="cargos">
                    <SingleFieldList>
                        <ChipField source="titulo" />
                    </SingleFieldList>
                </ArrayField>
                <TextField source="deparFuncs" />
                <TextField source="deparGerens" />
                <TextField source="salarios" />
            </Datagrid>
        </List>
    );
};

const Title = (props: any) => {
    return (
        <span>
            {props.record
                ? `${props.record.nome} ${props.record.sobrenome}`
                : ""}
        </span>
    );
};

export const EmployeeEdit: FC = (props) => (
    <Edit title={<Title />} {...props}>
        <SimpleForm>
            <TextInput disabled source="id" />
            <TextInput source="nome" />
            <TextInput source="sobrenome" />
            <TextInput source="cpf" />
            <TextInput source="genero" />
            <DateInput label="Data de Nascimento" source="dataNascimento" />
            <DateInput label="Data de contratação" source="dataContratacao" />
        </SimpleForm>
    </Edit>
);

export const EmployeeCreate: FC = (props) => (
    <Create title="Cadastrar um funcionário" {...props}>
        <SimpleForm>
            <TextInput disabled source="id" />
            <TextInput source="nome" />
            <TextInput source="sobrenome" />
            <TextInput source="cpf" />
            <TextInput source="genero" />
            <DateInput label="Data de Nascimento" source="dataNascimento" />
            <DateInput label="Data de contratação" source="dataContratacao" />
        </SimpleForm>
    </Create>
);
