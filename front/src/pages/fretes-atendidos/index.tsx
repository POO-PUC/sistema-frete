import { useContext, useState } from 'react';
import { FretesCalculosContext } from '../../contexts/FretesCalculosContext';
import MainLayout from '../../components/MainLayout';
import DataTable from '../../components/DataTable';
import styles from './styles.module.scss';
import { Header } from '../../components/Header';
import { Select } from '../../components/ui/Select';
import { Input } from '../../components/ui/Input'; // Importando o Input

import { EstadoContext } from '../../contexts/EstadoContext';

const PesquisaFretes: React.FC = () => {
    const { getFretesAtendidos, getFretesMedia, getFretesArrecadacao } = useContext(FretesCalculosContext)!;
    const { estados } = useContext(EstadoContext)!;

    const [mes, setMes] = useState<number>(0);
    const [ano, setAno] = useState<number>(0);
    const [idEstado, setIdEstado] = useState<number>(0);  // Filtro por código
    const [estado, setEstado] = useState<string>('');  // Filtro por nome
    const [activeTab, setActiveTab] = useState<string>('arrecadacao'); // Mudando a tab inicial para 'media'

    const [fretesAtendidos, setFretesAtendidos] = useState<any[]>([]);
    const [fretesMedia, setFretesMedia] = useState<any[]>([]);
    const [fretesArrecadacao, setFretesArrecadacao] = useState<any[]>([]);

    const handlePesquisaFretesAtendidos = async () => {
        const data = await getFretesAtendidos(mes, ano);
        setFretesAtendidos(data);
    };

    const handlePesquisaFretesMedia = async () => {
        const data = await getFretesMedia(idEstado);
        setFretesMedia(data);
    };

    const handlePesquisaFretesArrecadacao = async () => {
        const data = await getFretesArrecadacao(estado);  // Aqui passamos o nome do estado
        setFretesArrecadacao(data);
    };

    const columnsAtendidos = [
        { key: 'funcionario', label: 'Funcionário' },
        { key: 'empresa', label: 'Empresa' },
        { key: 'representante', label: 'Representante' },
        { key: 'data_frete', label: 'Data do Frete' },
    ];

    const columnsMedia = [
        { key: 'cidade', label: 'Cidade' },
        { key: 'estado', label: 'Estado' },
        { key: 'mediafreteorigem', label: 'Média Frete Origem' },
        { key: 'mediafretedestino', label: 'Média Frete Destino' },
    ];

    const columnsArrecadacao = [
        { key: 'cidade', label: 'Cidade' },
        { key: 'estado', label: 'Estado' },
        { key: 'quantidade_de_frete', label: 'Quantidade de Fretes' },
        { key: 'valor_total_arrecadado', label: 'Valor Total Arrecadado' },
    ];

    return (
        <MainLayout>
            <Header />
            <div className={styles.pesquisaFretesContainer}>
                <h1 className={styles.title}>Pesquisa de Fretes</h1>

                <div className={styles.tabs}>
                    <div
                        className={`${styles.tab} ${activeTab === 'arrecadacao' ? styles.activeTab : ''}`}
                        onClick={() => setActiveTab('arrecadacao')}
                    >
                        Fretes Arrecadação
                    </div>
                    <div
                        className={`${styles.tab} ${activeTab === 'media' ? styles.activeTab : ''}`}
                        onClick={() => setActiveTab('media')}
                    >
                        Fretes Média
                    </div>
                    <div
                        className={`${styles.tab} ${activeTab === 'atendidos' ? styles.activeTab : ''}`}
                        onClick={() => setActiveTab('atendidos')}
                    >
                        Fretes Atendidos
                    </div>
                </div>

                {activeTab === 'media' && (
                    <div className={styles.formGroup}>
                        <h3 className={styles.emptyMessage}>Quantidade média de fretes de origem e média de fretes de destino, por cidade de um estado informado por parâmetro.</h3>
                        <label>Estado</label>
                        <Select
                            value={idEstado}
                            onChange={(e) => setIdEstado(Number(e.target.value))}
                        >
                            <option value="">Selecione um estado</option>
                            {estados.map((estado) => (
                                <option key={estado.codigo} value={estado.codigo}>
                                    {estado.nome} ({estado.uf})
                                </option>
                            ))}
                        </Select>
                        <button onClick={handlePesquisaFretesMedia}>Pesquisar Fretes Média</button>
                    </div>
                )}

                {/* Conteúdo da Aba Arrecadação */}
                {activeTab === 'arrecadacao' && (
                    <div className={styles.formGroup}>
                        <h3 className={styles.emptyMessage}>Arrecadação com fretes, por cidade/estado de destino no ano 2024</h3>
                        <label>Estado</label>
                        <Select
                            value={estado} // Valor atual do nome do estado
                            onChange={(e) => setEstado(e.target.value)} // Atualiza o nome do estado
                        >
                            <option value="">Selecione um estado</option>
                            {estados.map((estado) => (
                                <option key={estado.codigo} value={estado.nome}>
                                    {estado.nome} ({estado.uf})
                                </option>
                            ))}
                        </Select>
                        <button onClick={handlePesquisaFretesArrecadacao}>Pesquisar Fretes Arrecadação</button>
                    </div>
                )}

                {/* Conteúdo da Aba Atendidos */}
                {activeTab === 'atendidos' && (
                    <div className={styles.formGroup}>
                        <h3 className={styles.emptyMessage}>Quais fretes os funcionários atenderam as pessoas jurídicas e quem eram os representantes destas empresas, no mes xx do ano yy</h3>
                        <div className={styles.inputsRow}>
                            {/* Dropdown para Mês */}
                            <div className={styles.inputWrapper}>
                                <label>Mês</label>
                                <Select
                                
                                    value={mes}
                                    onChange={(e) => setMes(Number(e.target.value))}
                                >
                                    <option value="">Selecione um mês</option>
                                    <option value={1}>Janeiro</option>
                                    <option value={2}>Fevereiro</option>
                                    <option value={3}>Março</option>
                                    <option value={4}>Abril</option>
                                    <option value={5}>Maio</option>
                                    <option value={6}>Junho</option>
                                    <option value={7}>Julho</option>
                                    <option value={8}>Agosto</option>
                                    <option value={9}>Setembro</option>
                                    <option value={10}>Outubro</option>
                                    <option value={11}>Novembro</option>
                                    <option value={12}>Dezembro</option>
                                </Select>
                            </div>
                            <label>Ano</label>
                                <Input
                                    type="number"
                                    value={ano}
                                    onChange={(e) => setAno(Number(e.target.value))}
                                    placeholder="Digite o ano"
                                    />
                            </div>
                        <button onClick={handlePesquisaFretesAtendidos}>Pesquisar Fretes Atendidos</button>
                    </div>
                )}


                {/* Exibição das tabelas de resultados */}
                {activeTab === 'media' && (
                    <div>
                        {fretesMedia.length === 0 ? (
                        <div className={styles.emptyMessage}> 
                           <p>Sem dados, ajuste os filtros e clique no botão para pesquisar...</p>
                       </div>
                        ) : (
                            <DataTable
                                data={fretesMedia}
                                columns={columnsMedia}
                                onRowClick={(item) => console.log(item)}
                            />
                        )}
                    </div>
                )}

                {activeTab === 'arrecadacao' && (
                    <div>
                        {fretesArrecadacao.length === 0 ? (
                            <div className={styles.emptyMessage}> 
                                <p>Sem dados, ajuste os filtros e clique no botão para pesquisar...</p>
                            </div>
                        ) : (
                            <DataTable
                                data={fretesArrecadacao}
                                columns={columnsArrecadacao}
                                onRowClick={(item) => console.log(item)}
                            />
                        )}
                    </div>
                )}

                {activeTab === 'atendidos' && (
                    <div>
                        {fretesAtendidos.length === 0 ? (
                        <div className={styles.emptyMessage}> 
                            <p>Sem dados, ajuste os filtros e clique no botão para pesquisar...</p>
                        </div>
                        ) : (
                            <DataTable
                                data={fretesAtendidos}
                                columns={columnsAtendidos}
                                onRowClick={(item) => console.log(item)}
                            />
                        )}
                    </div>
                )}

            </div>
        </MainLayout>
    );
};

export default PesquisaFretes;
